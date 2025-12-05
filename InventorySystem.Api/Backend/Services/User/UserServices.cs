using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services;

public interface IUserServices
{
    Task<UserRegistrationResultDto> RegisterUserAsync(CreateUserDto newUser);
    Task<UserLoginResultDto> AuthenticateUserAsync(UserLoginCredentialDto userCredential);    
    Task<UserLoginResultDto> RefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequest);
}

public class UserServices : IUserServices
{
    private readonly MyDbContext context;
    private readonly IConfiguration configuration;
    private readonly PasswordHasher<User> _passwordHasher;  // Reusable instance

    public UserServices(MyDbContext context, IConfiguration configuration)
    {
        this.context = context;
        this.configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();  // Initialize once
    }

    public async Task<UserRegistrationResultDto> RegisterUserAsync(CreateUserDto newUser)
    {
        var existingUser = await context.Tbl_Users
            .Where(u => u.Username == newUser.Username || u.Email == newUser.Email)
            .FirstOrDefaultAsync();

        if (existingUser != null)
        {
            if (existingUser.Username == newUser.Username)
                return new UserRegistrationResultDto(
                    false,
                    "Username already exists.",
                    null
                );

            if (existingUser.Email == newUser.Email)
                return new UserRegistrationResultDto(
                    false,
                    "Email already exists.",
                    null
                );
        }

        var user = newUser.ToUserEntity();
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, newUser.Password);

        context.Tbl_Users.Add(user);
        await context.SaveChangesAsync();

        return user.ToUserRegistrationDto(true, null);
    }

    public async Task<UserLoginResultDto> AuthenticateUserAsync(UserLoginCredentialDto userCredential)
    {
        bool isEmail = userCredential.UsernameOrEmail.Contains("@");

        var user = await context.Tbl_Users
            .FirstOrDefaultAsync(u => (isEmail ? u.Email : u.Username) == userCredential.UsernameOrEmail);

        if (user == null)
        {
            return new UserLoginResultDto(
                false,
                "Username or email does not exist.",
                string.Empty,
                string.Empty
            );
        }
        else if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userCredential.Password) == PasswordVerificationResult.Failed)
        {
            return new UserLoginResultDto(
                false,
                "Incorrect username, email, or password.",
                string.Empty,
                string.Empty
            );
        }
        else if (user.ApprovalStatus != ApprovalStatus.Approved)
        {
            return new UserLoginResultDto(
                    false,
                    "This account still needs to be approved by the company admin before it becomes active.",
                    string.Empty,
                    string.Empty
                );
        }

        UserLoginResultDto response = await CreateTokenResponse(user);
        return response;
    }

    private async Task<UserLoginResultDto> CreateTokenResponse(User user)
    {
        var CompanyFilter = user.Email.Split('@')[1].Split('.')[0].ToLower();
        var userRole = await context.Tbl_Company_User
                      .Include(cu => cu.Company)
                      .Where(cp => cp.UserId == user.Id && cp.Company != null && cp.Company.Company_Name.ToLower().StartsWith(CompanyFilter)).FirstOrDefaultAsync();
        UserForTokenCreationDto token = user.ToUserForTokenCreationDto(userRole is null ? "" : userRole.Role.ToString());

        return new UserLoginResultDto(
                true,
                "Login successful..",
                CreateToken(token),
                await GenerateAndSaveRefreshTokenAsync(user)
            );
    }

    public async Task<UserLoginResultDto> RefreshTokenAsync(RefreshTokenRequestDto request)
    {   
        if (!Guid.TryParse(request.UserId, out var userId))
        {
            return new UserLoginResultDto(
                    false,
                    "Invalid UserId format.",
                    string.Empty,
                    string.Empty
                );
        }
        
        var user = await ValidateRefreshTokenAsync(userId, request.RefreshToken);
        if (user == null)
        {
            return new UserLoginResultDto(
                    false,
                    "Invalid token or user not found.",
                    string.Empty,
                    string.Empty
                ); // Invalid token or user not found
        }
            
        return await CreateTokenResponse(user);
    }

    private async Task<User?> ValidateRefreshTokenAsync(Guid userId, string refreshToken)
    {
        var user = await context.Tbl_Users.FindAsync(userId);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return null; // Invalid token or user not found
        }

        return user;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }   

    private async Task<string> GenerateAndSaveRefreshTokenAsync(User user)
    {
        var refreshToken = GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(1); // Set expiry time as needed

        context.Tbl_Users.Update(user);
        await context.SaveChangesAsync();

        return refreshToken;
    }

    private string CreateToken(UserForTokenCreationDto userData)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userData.User.Id.ToString()),
            new Claim(ClaimTypes.Name, userData.User.Username),
            new Claim(ClaimTypes.GivenName, userData.User.Firstname),
            new Claim(ClaimTypes.Surname, userData.User.Lastname),
            new Claim(ClaimTypes.Email, userData.User.Email),
            new Claim(ClaimTypes.Role, userData.Role.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!)); // no need for 'GetValue<string>()'
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration["AppSettings:Issuer"],
            audience: configuration["AppSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(int.Parse(configuration["AppSettings:TokenExpirationMinutes"] ?? "1440")), // Default to 1 day (1440 mins)
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}

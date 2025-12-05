using System.ComponentModel.DataAnnotations;
using Backend.Entities;

namespace Backend.Dtos;

public record class UsersDto
(
    Guid Id,
    string Firstname,
    string Lastname,
    string Email,
    string Username,
    string Password
);

public record class UsersLoginDto
(    
    string Fullname,
    string Email,
    string Username,
    string Password
);

// START - DTO for creating and updating users
public record class CreateUserDto
(
    [Required][StringLength(50)] string Firstname,
    [Required][StringLength(50)] string Lastname,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(50)] string Username,
    [Required][StringLength(50)] string Password
);

public record class UserRegistrationResultDto
(    
    bool IsSuccess,
    string? ErrorMessage,
    User? User
);


public record class UpdateUserDto
(
    [Required][StringLength(50)] string Firstname,
    [Required][StringLength(50)] string Lastname,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(50)] string Username,
    [Required][StringLength(50)] string Password,
    [StringLength(50)] string Access,
    [Required] bool Status
);
// END - DTO for creating and updating users

// START - DTO for Login Module
public record class UserLoginCredentialDto
(
    string UsernameOrEmail,
    string Password
);  

public record class UserLoginResultDto
(    
    bool IsSuccess,
    string? ErrorMessage,
    string AccessToken,
    string RefreshToken
);


public record class TokenResponseDto
(
    string AccessToken,
    string RefreshToken
);

public record class RefreshTokenRequestDto
(
    string UserId,
    string RefreshToken
);

public record class UserForTokenCreationDto(
    User User,
    string Role
);

public record UserSessionDto
(
    Guid UserId,
    string Username,
    string Email,
    string Token
);

// END - DTO for Login Module


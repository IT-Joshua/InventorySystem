using System;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Mapping;

public static class UserMapping
{
    //User Entity to DTO
    public static UsersDto ToSummaryUsersDto(this User User)
    {
        return new(
            User.Id,
            User.Firstname,
            User.Lastname,
            User.Email,
            User.Username,
            User.PasswordHash
        );
    }

    public static UsersLoginDto ToLoginUsersDto(this User User)
    {
        return new(
            User.Firstname + " " + User.Lastname,
            User.Email,
            User.Username,
            User.PasswordHash
        );
    }
    
    public static UserRegistrationResultDto ToUserRegistrationDto(this User user, bool isSuccess, string? errorMessage)
    {
        return new(
            isSuccess,
            errorMessage,
            user    
        );
    }

       public static UserForTokenCreationDto ToUserForTokenCreationDto(this User user, string role)
    {
        return new(
            user,
            role
        );
    }

    //DTO to User Entity
    public static User ToUserEntity(this CreateUserDto item)
    {
        return new User()
        {
            Firstname = item.Firstname,
            Lastname = item.Lastname,
            Email = item.Email,
            Username = item.Username,
            PasswordHash = item.Password,
            ApprovalStatus = ApprovalStatus.Pending,
            IsActive = true
        };
    }

    //DTO TO DTO
    public static TokenResponseDto ToTokenResponseDto(this UserLoginResultDto item)
    {
        return new TokenResponseDto(
            item.AccessToken,
            item.RefreshToken
        );
    }
}

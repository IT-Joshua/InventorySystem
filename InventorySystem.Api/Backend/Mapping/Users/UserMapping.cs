using System;
using Backend.Dtos.Users;
using Backend.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Backend.Mapping.Users;

public static class UserMapping
{
    public static UsersDto ToSummaryUsersDto(this User_entity User)
    {
        return new(
            User.Id,
            User.Firstname,
            User.Lastname,
            User.Email,
            User.Username,
            User.Password,
            User.Access,
            User.Status
        );
    }

    public static UsersLoginDto ToLoginUsersDto(this User_entity User)
    {
        return new(
            User.Firstname + " " + User.Lastname,
            User.Email,
            User.Username,
            User.Password
        );
    }

    public static User_entity ToUserEntity(this CreateUserDto item)
    {
        return new User_entity()
        {
            Firstname = item.Firstname,
            Lastname = item.Lastname,
            Email = item.Email,
            Username = item.Username,
            Password = item.Password,
            Access = "Pending",
            Status = true
        };
    }
}

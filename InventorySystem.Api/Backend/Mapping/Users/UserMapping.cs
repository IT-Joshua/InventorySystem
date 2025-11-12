using System;
using Backend.Dtos.Users;
using Backend.Entities.Users;

namespace Backend.Mapping.Users;

public static class UserMapping
{
    public static UsersDto ToSummaryUsersDto(this Tbl_Users UsersDto)
    {
        return new(
            UsersDto.Id,
            UsersDto.Firstname,
            UsersDto.Lastname,
            UsersDto.Email,
            UsersDto.Username,
            UsersDto.Password,
            UsersDto.Access
        );
    }


    public static Tbl_Users ToEntity(this CreateUserDto item)
    {
        return new Tbl_Users()
        {
            Firstname = item.Firstname,
            Lastname = item.Lastname,
            Email = item.Email,
            Username = item.Username,
            Password = item.Password,
            Access = item.Access
        };
    }


}

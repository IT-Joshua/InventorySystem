using System;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Mapping;


public static class GrantAccessMapping
{
    //Grant Access
    public static GrantAccessDto ToGrantAccessList(this GrantAccess GrantAccessDto)
    {
        return new(
            GrantAccessDto.Id,
            GrantAccessDto.User!.Firstname,
            GrantAccessDto.User!.Lastname,
            GrantAccessDto.Access!.AccessName,
            GrantAccessDto.Status
        );
    }

    public static GrantAccess ToGrantAccessEntity(this AddGrantAccessDto item)
    {
        return new GrantAccess()
        {
            UserId = item.UserId,
            AccessId = item.AccessId,
            Status = item.Status
        };
    }
}
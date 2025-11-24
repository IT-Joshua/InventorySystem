using System;
using Backend.Dtos.Users;
using Backend.Entities.Users;

namespace Backend.Mapping.Users;


public static class GrantAccessMapping
{
    //Grant Access
    public static GrantAccessDto ToGrantAccessList(this Grant_Access_entity GrantAccessDto)
    {
        return new(
            GrantAccessDto.Id,
            GrantAccessDto.User!.Firstname,
            GrantAccessDto.User!.Lastname,
            GrantAccessDto.Access!.Access,
            GrantAccessDto.Status
        );
    }

    public static Grant_Access_entity ToGrantAccessEntity(this AddGrantAccessDto item)
    {
        return new Grant_Access_entity()
        {
            UserId = item.UserId,
            AccessId = item.AccessId,
            Status = item.Status
        };
    }
}
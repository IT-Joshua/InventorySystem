using System;
using Backend.Dtos.Users;
using Backend.Entities.Users;

namespace Backend.Mapping.Users;

public static class AccessMapping
{

//CRUD

    //READ
    public static AccessDto ToListAccess(this User_entity AccessDto)
    {
        return new(
            AccessDto.Id,
            AccessDto.Access
        );
    }

    //READ by id
    public static AccessDto ToListAccess(this User_entity AccessDto, int id)
    {
        return new(
            AccessDto.Id,
            AccessDto.Access
        );
    }

    //CREATE
    public static Access_entity ToAccessEntity(this AddAccessDto item)
    {
        return new Access_entity()
        {
            Access = item.Access
        };
    }

    //UPDATE
    public static Access_entity ToUpdateAccessEntity(this AddAccessDto item, int id)
    {
        return new Access_entity()
        {
            Id = id,
            Access = item.Access
        };
    }
}

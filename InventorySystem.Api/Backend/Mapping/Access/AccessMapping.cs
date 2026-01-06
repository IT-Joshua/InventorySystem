using System;
using Backend.Entities;
using Backend.Dtos;
using System.Data.Common;

namespace Backend.Mapping;

public static class AccessMapping
{

//CRUD

    //READ
    public static AccessDto ToListAccess(this Access_Entity entity)
    {
        return new(
            entity.Id.ToString(),            
            entity.Module!.Module_name,
            entity.AccessCode,
            entity.Description
        );
    }

    //READ by id
    public static AccessDto ToListAccessID(this Access_Entity entity, string id)
    {
        return new(
            entity.Id.ToString(),
            entity.Module!.Module_name,
            entity.AccessCode,
            entity.Description
        );
    }

    //CREATE
    public static Access_Entity ToAccessEntity(this AddAccessDto item)
    {
        return new Access_Entity
        {       
            Id = Guid.NewGuid(),    
            ModuleId = item.ModuleId,
            AccessCode = item.AccessCode,
            Description = item.Description
        };
    }

    //UPDATE
    public static Access_Entity ToUpdateAccessEntity(this AddAccessDto item, Guid id)
    {
        return new Access_Entity()
        {
            Id = id,
            ModuleId = item.ModuleId,
            AccessCode = item.AccessCode,
            Description = item.Description
        };
    }
}

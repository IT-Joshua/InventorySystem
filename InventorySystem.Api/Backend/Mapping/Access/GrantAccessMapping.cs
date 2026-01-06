using System;
using Backend.Entities;
using Backend.Dtos;

namespace Backend.Mapping;

public static class GrantAccessMapping
{
    //Grant Access
    public static GrantAccessDto ToGrantAccessList(this GrantAccess_Entity entity)
    {
        return new(
            entity.Id.ToString(),
            //Company
            entity.Company!.Company_Name,
            //user
            entity.User!.Firstname + entity.User!.Lastname,
            //access 
            entity.Access!.Module!.Module_name,
            entity.Access!.AccessCode,
            entity.Access!.Description,

            entity.Status
        );
    }

    public static GrantAccess_Entity ToGrantAccessEntity(this AddGrantAccessDto item)
    {
        return new GrantAccess_Entity()
        {
            Id = Guid.NewGuid(),
            CompanyId = item.CompanyId,
            UserId = item.UserId,
            AccessId = item.AccessId,
            Status = item.Status
        };
    }
}
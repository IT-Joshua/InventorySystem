using System;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Mapping;

public static class ModuleMapping
{
    //CRUD

    //READ
    public static ModuleDto ToListModule(this Module_Entity entity)
    {
        return new ModuleDto(
            entity.Id.ToString(),            
            entity.Module_name,
            entity.Description,
            entity.Is_active,
            entity.Created_at,
            entity.Updated_at
        );
    }

    //CREATE
    public static Module_Entity ToModuleEntity(this AddModuleDto item)
    {
        return new Module_Entity()
        {
            Module_name = item.Module_name,
            Description = item.Description
,           Is_active = item.Is_active, 
            Created_at = DateTime.Now,
            Updated_at = DateTime.Now
        };
    }
    //UPDATE
    public static Module_Entity ToUpdateModuleEntity(this AddModuleDto item, Guid id)
    {
        return new Module_Entity()
        {
            Id = id,
            Module_name = item.Module_name,
            Description = item.Description,
            Is_active = item.Is_active, 
            Created_at = item.Created_at,
            Updated_at = item.Updated_at
        };
    }
}
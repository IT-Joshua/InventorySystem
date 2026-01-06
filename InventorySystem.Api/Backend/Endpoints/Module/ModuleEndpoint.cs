using System.IO.Pipelines;
using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Backend.Endpoints;

public static class ModuleEndpoint
{
    public static RouteGroupBuilder MapModuleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Module").WithParameterValidation().WithTags("Access Endpoints");

        group.MapGet("/", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Module
            .Select(module => module.ToListModule())
            .AsNoTracking()
            .ToListAsync() ?? []
        );

        group.MapPost("/", async (AddModuleDto dto, MyDbContext dbContext) =>
        {
            Module_Entity module = dto.ToModuleEntity();
            dbContext.Tbl_Module.Add(module);
            await dbContext.SaveChangesAsync();
        });

        group.MapPut("/{ModuleId}", async (Guid ModuleId, AddModuleDto dto, MyDbContext dbContext) =>
        {
            var module = await dbContext.Tbl_Module.FindAsync(ModuleId);
            if (module == null)
            {
                return Results.NotFound("Module not found.");
            }

            dbContext
            .Entry(module)
            .CurrentValues
            .SetValues(dto.ToUpdateModuleEntity(ModuleId));
            await dbContext.SaveChangesAsync();

            return Results.Ok("Module updated successfully.");
        }

        );

        return group;
    }
}
using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class AccessEndpoint
{
    public static RouteGroupBuilder MapAccessEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Access").WithParameterValidation().WithTags("Access Endpoints");

        group.MapGet("/", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Access
            .Include(Module_entity => Module_entity.Module)
            .Select(access => access.ToListAccess())
            .AsNoTracking()
            .ToListAsync() ?? []
        );

        group.MapPost("/", async (AddAccessDto dto, MyDbContext dbContext) =>
        {
            Access_Entity access = dto.ToAccessEntity();
            dbContext.Tbl_Access.Add(access);
            await dbContext.SaveChangesAsync();
        });

        return group;
    }
}
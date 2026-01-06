using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class GrantAccessEndpoint
{
    public static RouteGroupBuilder MapGrantAccessEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("GrantAccess").WithParameterValidation();

        group.MapPost("/", async (AddGrantAccessDto AddGrantDto, MyDbContext dbContext) =>
          {
              GrantAccess_Entity GrantAccess = AddGrantDto.ToGrantAccessEntity();
              dbContext.Tbl_Grant_Access.Add(GrantAccess);
              await dbContext.SaveChangesAsync();
          });

        group.MapGet("/", async (MyDbContext dbContext) =>
             await dbContext.Tbl_Grant_Access
                .AsNoTracking()
                .Include(c => c.Company)
                .Include(c => c.User)
                .Include(c => c.Access)
                    .ThenInclude(c => c.Module)
                .Select(a => a.ToGrantAccessList())
                .ToListAsync()
        );

        group.MapGet("/{id}", async ( Guid id, MyDbContext dbContext) =>
             await dbContext.Tbl_Grant_Access
                .Where(Tbl_Grant_Access => Tbl_Grant_Access.UserId == id)
                .AsNoTracking()
                .Include(c => c.Company)
                .Include(c => c.User)
                .Include(c => c.Access)
                    .ThenInclude(c => c.Module)
                .Select(a => a.ToGrantAccessList())
                
                .ToListAsync()
        );

        group.MapDelete("/{id}", async (Guid id, MyDbContext dbContext) =>
        {
           await dbContext.Tbl_Grant_Access
                .Where(item => item.Id == id) 
                .ExecuteDeleteAsync();
        });

        group.MapGet("/C", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Company
            .Select(company => company.ToCompanySummaryDto())
            .AsNoTracking()
            .ToListAsync() ?? []
        );

        group.MapPost("/C", async (CreateCompanyDto newCompany, MyDbContext context) =>
        {
            Company company = newCompany.ToEntity();
            context.Tbl_Company.Add(company);
            await context.SaveChangesAsync();

            return Results.Ok("Company created successfully.");
        });

        return group;
    }
}
using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class CompanyUserEndpoint
{
    public static RouteGroupBuilder MapCompanyUserEndpoints(this WebApplication app)
    {
        const string GetCompanyUserByIdEndpointName = "GetCompanyUserById";

        var group = app.MapGroup("CompanyUser").WithParameterValidation().WithTags("Company User Endpoints");

        // Define CompanyUser related endpoints here
        
        group.MapGet("/", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Company_User
            .AsNoTracking()
            .ToListAsync()
        );

        group.MapGet("/{id}", async (Guid id, MyDbContext dbContext) =>
        {
            var companyUser =  await dbContext.Tbl_Company_User.Where(cu => cu.Id == id)
                .Include(cu => cu.Company)
                .Include(cu => cu.User)
                .FirstOrDefaultAsync();            

            return companyUser is not null ? Results.Ok(companyUser.ToCompanyUserDto()) : Results.NotFound("Company user not found.");
        }).WithName(GetCompanyUserByIdEndpointName);
        
        group.MapPost("/", async (CreateCompanyUserDto newCompanyUser, MyDbContext context) =>
        {
            CompanyUser companyUser = newCompanyUser.ToEntity();
            
            context.Tbl_Company_User.Add(companyUser);
            await context.SaveChangesAsync();

            // return Results.Ok("Company user created successfully.");
            return Results.CreatedAtRoute(GetCompanyUserByIdEndpointName, new { id = companyUser.Id }, companyUser.ToCompanyUserDto());
        });

        group.MapPut("/{id}", async (Guid id, UpdateCompanyUserDto updatedCompanyUser, MyDbContext context) =>
        {
            var existingCompanyUser = await context.Tbl_Company_User.FindAsync(id);
            if (existingCompanyUser == null)
            {
                return Results.NotFound("Company user not found.");
            }

            context.Entry(existingCompanyUser).CurrentValues.SetValues(updatedCompanyUser.ToEntity(id));
            await context.SaveChangesAsync();

            return Results.Ok("Company user updated successfully.");
        });
        return group;
    }
}

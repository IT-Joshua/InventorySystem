using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class CompanyEndpoint
{
    const string GetConnectionString = "";
    public static RouteGroupBuilder MapCompanyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Company").WithParameterValidation().WithTags("Company Endpoints");

        group.MapGet("/", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Company
            .Select(company => company.ToCompanySummaryDto())
            .AsNoTracking()
            .ToListAsync() ?? []
        ).RequireAuthorization(policy => policy.RequireRole("Admin", "SuperAdmin"));

        group.MapGet("/Ids", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Company
            .Select(company => company.ToCompanyDetailsDto())
            .AsNoTracking()
            .ToListAsync() ?? []
        ).RequireAuthorization(policy => policy.RequireRole("Admin", "SuperAdmin"));

        group.MapGet("/{id}", async (Guid id, MyDbContext dbContext) =>
        {
            var company = await dbContext.Tbl_Company.FindAsync(id);

            return company is not null ? Results.Ok(company.ToCompanySummaryDto()) : Results.NotFound("Company not found.");
        });

        group.MapPost("/", async (CreateCompanyDto newCompany, MyDbContext context) =>
        {
            Company company = newCompany.ToEntity();
            context.Tbl_Company.Add(company);
            await context.SaveChangesAsync();

            return Results.Ok("Company created successfully.");
        });

        group.MapPut("/{id}", async (Guid id, UpdateCompanyDto updatedCompany, MyDbContext context) =>
        {
            var existingCompany = await context.Tbl_Company.FindAsync(id);
            if (existingCompany == null)
            {
                return Results.NotFound("Company not found.");
            }

            context.Entry(existingCompany).CurrentValues.SetValues(updatedCompany.ToEntity(id));
            await context.SaveChangesAsync();

            return Results.Ok("Company updated successfully.");
        });

        return group;
    }
}

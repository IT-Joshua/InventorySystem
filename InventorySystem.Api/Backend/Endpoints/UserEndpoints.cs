using System;
using Backend.Data;
using Backend.Dtos.Users;
using Backend.Entities.Users;
using Backend.Mapping.Users;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class UserEndpoints
{
    const string GetConnectionString = "newUser";

    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("User").WithParameterValidation();

        group.MapGet("/test", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Users
            .AsNoTracking()
            .ToListAsync()
        );

        //add value
        group.MapPost("/test", async (CreateUserDto newUser, MyDbContext dbContext) =>
          {
              Tbl_Users User = newUser.ToEntity();
              dbContext.Tbl_Users.Add(User);
              await dbContext.SaveChangesAsync();
          });

        return group;
    }
}

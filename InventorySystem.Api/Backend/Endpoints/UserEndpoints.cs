using System;
using Backend.Data;
using Backend.Data.Migrations;
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

        group.MapGet("/", async (MyDbContext dbContext) =>
            await dbContext.Tbl_Users
            .AsNoTracking()
            .ToListAsync()
        );

        //per username
        group.MapGet("/{username_email}/{Logtype}", async (string username_email, string Logtype, MyDbContext dbContext) =>

            {
                var users = await dbContext.Tbl_Users
                        .Where(User => (User.Username == username_email || User.Email == username_email) && User.Status != false && User.Access != "")
                        .AsNoTracking()
                        .ToListAsync();
                try
                {
                    if (users.Any())
                    {
                        var user = users.First();

                        var log = new Tbl_Logs
                        {
                            UserId = user.Id,
                            Log_type = Logtype,
                            Log_message = "Success",
                            Error_id = 0
                        };

                        dbContext.Tbl_Logs.Add(log);
                        await dbContext.SaveChangesAsync();
                    }
                }
                catch
                {
                    var user = users.First();

                        var log = new Tbl_Logs
                        {
                            UserId = user.Id,
                            Log_type = Logtype,
                            Log_message = "Success",
                            Error_id = 0
                        };

                        dbContext.Tbl_Logs.Add(log);
                        await dbContext.SaveChangesAsync();
                }
                return users;

            });

        //add value
        group.MapPost("/", async (CreateUserDto newUser, MyDbContext dbContext) =>
          {
              Tbl_Users User = newUser.ToUserEntity();
              dbContext.Tbl_Users.Add(User);
              await dbContext.SaveChangesAsync();
          });

        group.MapGet("/Access", async (MyDbContext dbContext) =>
             await dbContext.Tbl_Access
                .AsNoTracking()
                .ToListAsync()
        );
        //access
        group.MapPost("/Access", async (AddAccessDto addAccess, MyDbContext dbContext) =>
            {
                Tbl_Access Access = addAccess.ToAccessEntity();
                dbContext.Tbl_Access.Add(Access);
                await dbContext.SaveChangesAsync();
            }
        );

        group.MapPut("/Access/{id}", async (int id, AddAccessDto updateAccess, MyDbContext dbContext) =>
            {
                var existingItem = await dbContext.Tbl_Access.FindAsync(id);
                if (existingItem is null) { return Results.NotFound(); }

                dbContext.Entry(existingItem)
                    .CurrentValues
                    .SetValues(updateAccess.ToUpdateAccessEntity(id));

                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            }
        );

        group.MapGet("/ViewAccess/{userid}", async (int userid, MyDbContext dbContext) =>
             await dbContext.Tbl_Grant_Access
             .Where(Tbl_Grant_Access => Tbl_Grant_Access.UserId == userid)
             .Include(Tbl_Users => Tbl_Users.User)
             .Include(Tbl_Access => Tbl_Access.Access)
             .Select(Tbl_Grant_Access => Tbl_Grant_Access.ToGrantAccessList())
                .AsNoTracking()
                .ToListAsync()
        );

        group.MapPost("/GrantAccess", async (AddGrantAccessDto GrantAccess, MyDbContext dbContext) =>
            {
                Tbl_Grant_Access Access = GrantAccess.ToGrantAccessEntity();
                dbContext.Tbl_Grant_Access.Add(Access);
                await dbContext.SaveChangesAsync();
            }
        );

        //logs  
        group.MapGet("/Logs/{userid}", async (int userid, MyDbContext dbContext) =>
             await dbContext.Tbl_Logs
             .Where(Tbl_Logs => Tbl_Logs.UserId == userid)
             .Include(Tbl_Users => Tbl_Users.User)
             .Select(Tbl_Logs => Tbl_Logs.ToLogsList())
                .AsNoTracking()
                .ToListAsync()
        );

        group.MapPost("/Logs", async (AddLogsDto Logs, MyDbContext dbContext) =>
           {
               Tbl_Logs tbl_Logs = Logs.ToLogsEntity();
               dbContext.Tbl_Logs.Add(tbl_Logs);
               await dbContext.SaveChangesAsync();
           }
        );


        return group;
    }
}

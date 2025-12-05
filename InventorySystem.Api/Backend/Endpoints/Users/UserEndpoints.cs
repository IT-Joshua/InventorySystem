using Backend.Data;
using Backend.Dtos;
using Backend.Entities;
using Backend.Mapping;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class UserEndpoints
{
    const string GetConnectionString = "newUser";

    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("User").WithParameterValidation().WithTags("User Endpoints");

        // group.MapGet("/", async (MyDbContext dbContext) =>
        //     await dbContext.Tbl_Users
        //     .AsNoTracking()
        //     .ToListAsync()
        // );

        //per username
        group.MapGet("/{username_email}", async (string username_email, string Logtype, MyDbContext dbContext) =>
            {
                var users = await dbContext.Tbl_Users
                        .Where(Tbl_Users => (Tbl_Users.Username == username_email || Tbl_Users.Email == username_email) && Tbl_Users.IsActive && Tbl_Users.ApprovalStatus != ApprovalStatus.Pending)
                        // .Select(Tbl_Users => Tbl_Users.ToLoginUsersDto())
                        .AsNoTracking()
                        .ToListAsync();
                try
                {
                    if (users.Any())
                    {
                        var user = users.First();

                        var log = new Log
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

                    var log = new Log
                    {
                        UserId = user.Id,
                        Log_type = Logtype,
                        Log_message = "Success",
                        Error_id = 0
                    };

                    dbContext.Tbl_Logs.Add(log);
                    await dbContext.SaveChangesAsync();
                }

                var dtoList = users.Select(u => u.ToLoginUsersDto()).ToList();

                return Results.Ok(dtoList);

        });
        
        //add value
        group.MapPost("/", async (CreateUserDto newUser, MyDbContext dbContext) =>
        {
              User User = newUser.ToUserEntity();
              dbContext.Tbl_Users.Add(User);
              await dbContext.SaveChangesAsync();
        });

        group.MapPost("/register", async (CreateUserDto newUser, MyDbContext dbContext, IUserServices userServices) =>
        {
           var result  = await userServices.RegisterUserAsync(newUser);
           if (!result.IsSuccess)
                return Results.BadRequest(result.ErrorMessage);

            return Results.Ok(result.User);
        });

        group.MapPost("/login", async (UserLoginCredentialDto userCredential, MyDbContext dbContext, IUserServices userServices) =>
        {
           var result = await userServices.AuthenticateUserAsync(userCredential);
            if (!result.IsSuccess)
            {   
                return Results.BadRequest(result.ErrorMessage);
            }
            return Results.Ok(result.ToTokenResponseDto());
        });

        group.MapPost("/refresh-token", async (RefreshTokenRequestDto refreshTokenRequest, MyDbContext dbContext, IUserServices userServices) =>
        {        
            var result = await userServices.RefreshTokenAsync(refreshTokenRequest);
            if (!result.IsSuccess)
            {   
                return Results.BadRequest(result.ErrorMessage);
            }
            return Results.Ok(result.ToTokenResponseDto());
        });

        group.MapGet("/Auth", async () =>
        {
            return Results.Ok("User Endpoint is working!");   
        }).RequireAuthorization(policy => policy.RequireRole("Admin", "SuperAdmin"));
  

        // group.MapGet("/Access", async (MyDbContext dbContext) =>
        //      await dbContext.Tbl_Access
        //         .AsNoTracking()
        //         .ToListAsync()
        // );
        // //access
        // group.MapPost("/Access", async (AddAccessDto addAccess, MyDbContext dbContext) =>
        //     {
        //         Access_entity Access = addAccess.ToAccessEntity();
        //         dbContext.Tbl_Access.Add(Access);
        //         await dbContext.SaveChangesAsync();
        //     }
        // );

        // group.MapPut("/Access/{id}", async (int id, AddAccessDto updateAccess, MyDbContext dbContext) =>
        //     {
        //         var existingItem = await dbContext.Tbl_Access.FindAsync(id);
        //         if (existingItem is null) { return Results.NotFound(); }

        //         dbContext.Entry(existingItem)
        //             .CurrentValues
        //             .SetValues(updateAccess.ToUpdateAccessEntity(id));

        //         await dbContext.SaveChangesAsync();
        //         return Results.NoContent();
        //     }
        // );

        // group.MapGet("/ViewAccess/{userid}", async (int userid, MyDbContext dbContext) =>
        //      await dbContext.Tbl_Grant_Access
        //      .Where(Grant_Access_entity => Grant_Access_entity.UserId == userid)
        //      .Include(Users_entity => Users_entity.User)
        //      .Include(Access_entity => Access_entity.Access)
        //      .Select(Grant_Access_entity => Grant_Access_entity.ToGrantAccessList())
        //         .AsNoTracking()
        //         .ToListAsync()
        // );

        // group.MapPost("/GrantAccess", async (AddGrantAccessDto GrantAccess, MyDbContext dbContext) =>
        //     {
        //         Grant_Access_entity Access = GrantAccess.ToGrantAccessEntity();
        //         dbContext.Tbl_Grant_Access.Add(Access);
        //         await dbContext.SaveChangesAsync();
        //     }
        // );

        // //logs  
        // group.MapGet("/Logs/{userid}", async (int userid, MyDbContext dbContext) =>
        //      await dbContext.Tbl_Logs
        //      .Where(Logs_entity => Logs_entity.UserId == userid)
        //      .Include(User_entity => User_entity.User)
        //      .Select(Logs_entity => Logs_entity.ToLogsList())
        //         .AsNoTracking()
        //         .ToListAsync()
        // );

        // group.MapPost("/Logs", async (AddLogsDto Logs, MyDbContext dbContext) =>
        //    {
        //        Logs_entity tbl_Logs = Logs.ToLogsEntity();
        //        dbContext.Tbl_Logs.Add(tbl_Logs);
        //        await dbContext.SaveChangesAsync();
        //    }
        // );


        return group;
    }
}

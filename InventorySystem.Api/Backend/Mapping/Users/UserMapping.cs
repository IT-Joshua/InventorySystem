using System;
using Backend.Dtos.Users;
using Backend.Entities.Users;

namespace Backend.Mapping.Users;

public static class UserMapping
{
    public static UsersDto ToSummaryUsersDto(this Tbl_Users UsersDto)
    {
        return new(
            UsersDto.Id,
            UsersDto.Firstname,
            UsersDto.Lastname,
            UsersDto.Email,
            UsersDto.Username,
            UsersDto.Password,
            UsersDto.Access,
            UsersDto.Status
        );
    }

    public static Tbl_Users ToUserEntity(this CreateUserDto item)
    {
        return new Tbl_Users()
        {
            Firstname = item.Firstname,
            Lastname = item.Lastname,
            Email = item.Email,
            Username = item.Username,
            Password = item.Password,
            Access = item.Access,
            Status = item.Status
        };
    }

    public static AccessDto ToListAccess(this Tbl_Access AccessDto)
    {
        return new(
            AccessDto.Id,
            AccessDto.Access
        );
    }

    public static Tbl_Access ToAccessEntity(this AddAccessDto item)
    {
        return new Tbl_Access()
        {
            Access = item.Access
        };
    }

    public static Tbl_Access ToUpdateAccessEntity(this AddAccessDto item, int id)
    {
        return new Tbl_Access()
        {
            Id = id,
            Access = item.Access
        };
    }

    //Grant Access
    public static GrantAccessDto ToGrantAccessList(this Tbl_Grant_Access GrantAccessDto)
    {
        return new(
            GrantAccessDto.Id,
            GrantAccessDto.User!.Firstname,
            GrantAccessDto.User!.Lastname,
            GrantAccessDto.Access!.Access,
            GrantAccessDto.Status
        );
    }

    public static Tbl_Grant_Access ToGrantAccessEntity(this AddGrantAccessDto item)
    {
        return new Tbl_Grant_Access()
        {
            UserId = item.UserId,
            AccessId = item.AccessId,
            Status = item.Status
        };
    }


    //logs
    public static LogsDto ToLogsList(this Tbl_Logs LogsDto)
    {
        return new(
            LogsDto.Id,
            LogsDto.User!.Firstname,
            LogsDto.User!.Lastname,
            LogsDto.Log_type,
            LogsDto.Log_message,
            LogsDto.Error_id,
            LogsDto.Datetime.ToString("MMM-dd-yyyy")
        );
    }

    public static Tbl_Logs ToLogsEntity(this AddLogsDto item)
    {
        return new Tbl_Logs()
        {
            UserId = item.UserId,
            Log_type = item.Log_type,
            Log_message = item.Log_message,
            Error_id = item.Error_id
        };
    }





}

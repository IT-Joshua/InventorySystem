using System;
using Backend.Dtos.Users;
using Backend.Entities.Users;

namespace Backend.Mapping.Users;

//logs
public static class LogsMapping
{
    public static LogsDto ToLogsList(this Logs_entity LogsDto)
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

    public static Logs_entity ToLogsEntity(this AddLogsDto item)
    {
        return new Logs_entity()
        {
            UserId = item.UserId,
            Log_type = item.Log_type,
            Log_message = item.Log_message,
            Error_id = item.Error_id
        };
    }
}

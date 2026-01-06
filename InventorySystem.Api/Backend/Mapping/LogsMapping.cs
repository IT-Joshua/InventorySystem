using System;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Mapping;

//logs
public static class LogsMapping1
{
    public static LogsDto ToLogsList(this Log LogsDto)
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

    public static Log ToLogsEntity(this AddLogsDto item)
    {
        return new Log()
        {
            UserId = item.UserId,
            Log_type = item.Log_type,
            Log_message = item.Log_message,
            Error_id = item.Error_id
        };
    }
}

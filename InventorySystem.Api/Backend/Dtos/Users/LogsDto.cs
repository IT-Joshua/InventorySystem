using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public record class LogsDto
(
    Guid Id,
    string Firstname,
    string Lastname,
    string Log_type,
    string Log_message,
    int Error_id,
    string Datetime
);
public record class AddLogsDto
(   
    [Required] Guid UserId,
    [Required][StringLength(100)] string Log_type,
    [Required][StringLength(100)] string Log_message,
    int Error_id
);

using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;

namespace Backend.Dtos.Users;

public record class LogsDto
(
    int Id,
    string Firstname,
    string Lastname,
    string Log_type,
    string Log_message,
    int Error_id,
    string Datetime
);
public record class AddLogsDto
(   
    [Required] int UserId,
    [Required][StringLength(100)] string Log_type,
    [Required][StringLength(100)] string Log_message,
    int Error_id
);

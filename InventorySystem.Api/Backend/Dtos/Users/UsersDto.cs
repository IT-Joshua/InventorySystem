using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;

namespace Backend.Dtos.Users;

public record class UsersDto
(
    int Id,
    string Firstname,
    string Lastname,
    string Email,
    string Username,
    string Password,
    string? Access,
    bool Status
);

public record class CreateUserDto
(
    [Required][StringLength(50)] string Firstname,
    [Required][StringLength(50)] string Lastname,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(50)] string Username,
    [Required][StringLength(50)] string Password,
    [StringLength(50)] string Access,
    [Required] bool Status
);

public record class UpdateUserDto
(
    [Required][StringLength(50)] string Firstname,
    [Required][StringLength(50)] string Lastname,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(50)] string Username,
    [Required][StringLength(50)] string Password,
    [StringLength(50)] string Access,
    [Required] bool Status
);


//Access
public record class AccessDto
(
    int Id,
    string Access
);
public record class AddAccessDto
(
    [Required][StringLength(50)] string Access
);

//GrantAccess
public record class GrantAccessDto
(
    int Id,
    string Firstname,
    string Lastname,
    string Access,
    bool Status
);

public record class AddGrantAccessDto
(
    [Required] int UserId,
    [Required] int AccessId,
    [Required] bool Status
);

//Logs

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




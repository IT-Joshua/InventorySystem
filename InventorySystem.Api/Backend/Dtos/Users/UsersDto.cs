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
    string Access,
    bool Status
);

public record class UsersLoginDto
(    
    string Fullname,
    string Email,
    string Username,
    string Password
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






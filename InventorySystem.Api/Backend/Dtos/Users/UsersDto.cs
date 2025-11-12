using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Users;

public record class UsersDto
(
    int Id,
    string Firstname,
    string Lastname,
    string Email,
    string Username,
    string Password,
    string Access
);

public record class CreateUserDto
(
    [Required][StringLength(100)] string Firstname,
    [Required][StringLength(100)] string Lastname,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(100)] string Username,
    [Required][StringLength(100)] string Password,
    [Required][StringLength(100)] string Access
);

public record class UpdateUserDto
(
    [Required][StringLength(100)] string Firstname,
    [Required][StringLength(100)] string Lastname,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(100)] string Username,
    [Required][StringLength(100)] string Password,
    [StringLength(100)] string Access
);

using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;

namespace Backend.Dtos.Users;
public record class AccessDto
(
    int Id,
    string Access
);
public record class AddAccessDto
(
    [Required][StringLength(50)] string Access
);
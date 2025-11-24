using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;

namespace Backend.Dtos.Users;
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
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;
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
    [Required] Guid UserId,
    [Required] int AccessId,
    [Required] bool Status
);
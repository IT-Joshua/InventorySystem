using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;
public record class AccessDto
(
    Guid Id,
    string Access
);
public record class AddAccessDto
(
    [Required][StringLength(50)] string Access
);
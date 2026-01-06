using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;
public record class AccessDto1
(
    Guid Id,
    string Access
);
public record class AddAccessDto1
(
    [Required][StringLength(50)] string Access
);
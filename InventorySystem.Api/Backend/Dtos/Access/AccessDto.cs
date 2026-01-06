using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;
public record class AccessDto
(
    string Id,    
    string ModuleName,
    string AccessCode,
    string Description

);
public record class AddAccessDto
(
    [Required] Guid ModuleId,
    [Required][StringLength(50)] string AccessCode,
    [Required] string Description
);
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;
public record class ModuleDto
(
    string Id,    
    string Module_name,
    string? Description,
    bool Is_active,
    DateTime Created_at,
    DateTime Updated_at
);
public record class AddModuleDto
(
    string Module_name,
    string? Description,
    bool Is_active, 
    DateTime Created_at,
    DateTime Updated_at    
);
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;
public record class GrantAccessDto
(
    string Id,
    //Company
    string CompanyName,
    //user
    string FullName,
    //access 
    string ModuleName,
    string AccessCode,
    string AccessDescription,

    bool Status
);

public record class AddGrantAccessDto
(
    [Required] Guid CompanyId,
    [Required] Guid UserId,
    [Required] Guid AccessId,
    [Required] bool Status
);
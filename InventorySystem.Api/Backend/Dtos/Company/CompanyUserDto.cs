using System;
using Backend.Entities;

namespace Backend.Dtos;

public record class CompanyUserDto
(
   string CompanyName,
   string UserFullName,
   string RoleName
);

public record class CreateCompanyUserDto(
    Guid CompanyId,
    Guid UserId,
    Role Role
);

public record class UpdateCompanyUserDto(
    Guid Id,
    Guid CompanyId,
    Guid UserId,
    Role Role,
    bool Is_Active    
);
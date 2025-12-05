using System;

namespace Backend.Dtos;

public record class UserCompanyRoleDto
(
    string RoleName
);

public record CompanyDetailsDto
(
    string Company_Id,
    string Company_Name,
    string Prefix,
    string Transaction_Prefix,
    int Transaction_Series,
    string Transaction_Format
);

public record CompanySummaryDto
(
    string Company_Name,
    string Prefix,
    string Transaction_Prefix,
    int Transaction_Series,
    string Transaction_Format
);

public record CreateCompanyDto
(
    string Company_Name,
    string Prefix,
    string Transaction_Prefix,
    int Transaction_Series,
    string Transaction_Format,
    bool Is_Active
);

public record UpdateCompanyDto
(
    string Company_Name,
    string Prefix,
    string Transaction_Prefix,
    int Transaction_Series,
    string Transaction_Format,
    bool Is_Active
);
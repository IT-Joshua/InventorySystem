using System;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Mapping;

public static class CompanyUserMapping
{
    //To Entity
    public static CompanyUser ToEntity(this CreateCompanyUserDto newCompany)
    {
        return new CompanyUser
        {
            Id = Guid.NewGuid(),
            CompanyId = newCompany.CompanyId,
            UserId = newCompany.UserId,
            Role = newCompany.Role,
            Is_Active = true,
            Created_Timestamp = DateTime.UtcNow
        };
    }

    public static CompanyUser ToEntity(this UpdateCompanyUserDto updateCompany, Guid id)
    {
        return new CompanyUser
        {
            Id = id,
            CompanyId = updateCompany.CompanyId,
            UserId = updateCompany.UserId,
            Role = updateCompany.Role,
            Is_Active = updateCompany.Is_Active,
            Updated_Timestamp = DateTime.UtcNow
        };
    }
    
    //To DTO
    public static CompanyUserDto ToCompanyUserDto(this CompanyUser companyUser)
    {
        return new CompanyUserDto
        (
            CompanyName: companyUser.Company is null ? "" : companyUser.Company.Company_Name,
            UserFullName: companyUser.User is null ? "" : companyUser.User.Firstname + " " + companyUser.User.Lastname,
            RoleName: companyUser.Role.ToString()
        );
    }
}

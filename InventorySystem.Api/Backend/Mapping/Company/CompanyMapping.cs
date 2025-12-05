using System;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Mapping;

public static class CompanyMapping
{   
    //To Entity
    public static Company ToEntity(this CreateCompanyDto dto)
    {
        return new Company
        {
            Id = Guid.NewGuid(),
            Company_Name = dto.Company_Name,
            Prefix = dto.Prefix,
            Transaction_Prefix = dto.Transaction_Prefix,
            Transaction_Series = dto.Transaction_Series,
            Transaction_Format = dto.Transaction_Format,
            Is_Active = dto.Is_Active,
            Created_Timestamp = DateTime.UtcNow,
            Updated_Timestamp = DateTime.UtcNow
        };
    }

    public static Company ToEntity(this UpdateCompanyDto dto, Guid id)
    {
        return new Company
        {
            Id = id,
            Company_Name = dto.Company_Name,
            Prefix = dto.Prefix,
            Transaction_Prefix = dto.Transaction_Prefix,
            Transaction_Series = dto.Transaction_Series,
            Transaction_Format = dto.Transaction_Format,
            Is_Active = dto.Is_Active,
            Updated_Timestamp = DateTime.UtcNow
        };
    }

    //To DTO
    public static CompanySummaryDto ToCompanySummaryDto(this Company company)
    {
        return new CompanySummaryDto
        (
            company.Company_Name,
            company.Prefix,
            company.Transaction_Prefix,
            company.Transaction_Series,
            company.Transaction_Format
        );
    }

    public static CompanyDetailsDto ToCompanyDetailsDto(this Company company)
    {
        return new CompanyDetailsDto
        (
            company.Id.ToString(),
            company.Company_Name,
            company.Prefix,
            company.Transaction_Prefix,
            company.Transaction_Series,
            company.Transaction_Format
        );
    }
}

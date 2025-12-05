using System;

namespace Frontend.Models;

public class CompanySummary
{
    public required string Company_Name {get;set;}
    public required string  Prefix {get;set;}
    public required string Transaction_Prefix {get;set;}
    public int Transaction_Series {get;set;}
    public required string Transaction_Format {get;set;}
}

public class CompanyDetails
{
    public string? Company_Id {get; set;}
    public required string Company_Name {get;set;}
    public required string  Prefix {get;set;}
    public required string Transaction_Prefix {get;set;}
    public int Transaction_Series {get;set;}
    public required string Transaction_Format {get;set;}
}


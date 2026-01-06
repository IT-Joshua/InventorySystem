using System;
using System.ComponentModel.DataAnnotations;
namespace Backend.Entities;
public class GrantAccess_Entity
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid AccessId { get; set; }
    public Access_Entity? Access { get; set; }
    public bool Status { get; set; }
}
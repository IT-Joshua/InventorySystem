using System;
using System.ComponentModel.DataAnnotations;
namespace Backend.Entities;

public class Access_Entity
{ 
    public Guid Id { get; set; }    
    public Guid? ModuleId { get; set; }
    public Module_Entity? Module { get; set; }

    [MaxLength(50)]
    public required string AccessCode { get; set; }
    public required string Description { get; set; }
}
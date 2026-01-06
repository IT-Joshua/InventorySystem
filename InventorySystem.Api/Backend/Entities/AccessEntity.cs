using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public class Access1
{ 
    public int Id { get; set; }
    [MaxLength(50)]
    public required string AccessName { get; set; }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Users;

public class Access_entity
{ 
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Access { get; set; }
}
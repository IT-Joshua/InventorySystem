using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Users;

public class User_entity
{
    public int Id { get; set; }

    [MaxLength(50)]
    public required string Firstname { get; set; }

    [MaxLength(50)]
    public required string Lastname { get; set; }

    [MaxLength(100)]
    public required string Email { get; set; }
    
    [MaxLength(50)]
    public required string Username { get; set; }  

    [MaxLength(50)]
    public required string Password { get; set; }

    [MaxLength(50)]
    public string Access { get; set; }
    
    public required bool Status { get; set; }
    public DateTime? Forgotpassword { get; set; }
}








using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Users;

public class Tbl_Users
{
    public int Id { get; set; }

    [MaxLength(20)]
    public required string Firstname { get; set; }

    [MaxLength(20)]
    public required string Lastname { get; set; }

    [MaxLength(20)]
    public required string Email { get; set; }
    
    [MaxLength(20)]
    public required string Username { get; set; }  

    [MaxLength(20)]
    public required string Password { get; set; }

    [MaxLength(20)]
    public string? Access { get; set; }
    
    public required bool Status { get; set; }
}

public class Tbl_Access
{ 
    public int Id { get; set; }
    [MaxLength(20)]
    public required string Access { get; set; }
}

public class Tbl_Grant_Access
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Tbl_Users? User { get; set; }
    public int AccessId { get; set; }
    public Tbl_Access? Access { get; set; }
    public bool Status { get; set; }
}

public class Tbl_Logs
{ 
    public int Id { get; set; }
    public int UserId { get; set; }
    public Tbl_Users? User { get; set; }
    [MaxLength(20)]
    public required string Log_type { get; set; }
    [MaxLength(20)]
    public required string Log_message { get; set; }
    public int Error_id { get; set; }
    public DateTime Datetime { get; set; }
}


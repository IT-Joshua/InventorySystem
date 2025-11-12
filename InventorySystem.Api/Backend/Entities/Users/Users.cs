using System;

namespace Backend.Entities.Users;

public class Tbl_Users
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }  
    public required string Password { get; set; }
    public required string Access { get; set; }
}

public class Tbl_Access
{ 
    public int Id { get; set; }
    public required string Access { get; set; }
}

public class Tbl_Assigned_Access
{
    public int Id { get; set; }
    public int User_Id { get; set; }
    public Tbl_Users? User { get; set; }
    public int Access_Id { get; set; }
    public Tbl_Access? AccessId { get; set; }
}

public class Tbl_Logs
{ 
    public int Id { get; set; }
    public int User_Id { get; set; }
    public Tbl_Users? User { get; set; }
    public required string Log_type { get; set; }
    public required string Log_message { get; set; }
    public int Error_id { get; set; }
    public DateTime Datetime { get; set; }
}


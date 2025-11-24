using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Users;
public class Logs_entity
{ 
    public int Id { get; set; }
    public int UserId { get; set; }
    public User_entity? User { get; set; }
    [MaxLength(100)]
    public required string Log_type { get; set; }
    public required string Log_message { get; set; }
    public int Error_id { get; set; }
    public DateTime Datetime { get; set; }
}
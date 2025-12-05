using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;
public class Log
{ 
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    [MaxLength(100)]
    public required string Log_type { get; set; }
    public required string Log_message { get; set; }
    public int Error_id { get; set; }
    public DateTime Datetime { get; set; }
}
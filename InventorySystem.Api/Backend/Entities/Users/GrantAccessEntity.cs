using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Users;
public class Grant_Access_entity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User_entity? User { get; set; }
    public int AccessId { get; set; }
    public Access_entity? Access { get; set; }
    public bool Status { get; set; }
}

namespace Backend.Entities;

public class Module_Entity
{
    public Guid Id { get; set; }
    public required string Module_name { get; set; }
    public string? Description { get; set; }
    public bool Is_active { get; set; } 
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}
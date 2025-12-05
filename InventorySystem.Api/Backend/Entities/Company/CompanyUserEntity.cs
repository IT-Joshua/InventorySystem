
namespace Backend.Entities;

public class CompanyUser
{
    public Guid Id { get; set; }
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; } 

    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public required Role Role { get; set; }
    public required bool Is_Active { get; set; }
    public DateTime Created_Timestamp { get; set; }
    public DateTime Updated_Timestamp { get; set; }
}

public enum Role
{
    User,
    Admin,
    SuperAdmin
}




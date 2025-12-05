using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public class User
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public required string Firstname { get; set; }

    [MaxLength(50)]
    public required string Lastname { get; set; }

    [MaxLength(100)]
    public required string Email { get; set; }

    [MaxLength(50)]
    public required string Username { get; set; }

    public required string PasswordHash { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }

    public required bool IsActive { get; set; }

    public string? RefreshToken { get; set; } = string.Empty;

    public DateTime? RefreshTokenExpiryTime { get; set; }
    
    public DateTime? Forgotpassword { get; set; }
}

public enum ApprovalStatus
{
    Pending,
    Approved,
    Rejected
}




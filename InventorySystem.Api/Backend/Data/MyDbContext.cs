using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public DbSet<User> Tbl_Users { get; set; }
    public DbSet<Access_Entity> Tbl_Access { get; set; }
    public DbSet<GrantAccess_Entity> Tbl_Grant_Access { get; set; }
    public DbSet<Module_Entity> Tbl_Module { get; set; }
    public DbSet<Log> Tbl_Logs { get; set; }
    public DbSet<CompanyUser> Tbl_Company_User { get; set; }
    public DbSet<Company> Tbl_Company { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Access>().HasData(
        //     new { Id = 1, AccessName = "View Module 1" },
        //     new { Id = 2, AccessName = "Add Module 1" },
        //     new { Id = 3, AccessName = "Edit Module 1" }
        // );

        // modelBuilder.Entity<User>().HasData(
        
        //     new { Id = Guid.NewGuid(), Firstname = "Mark", Lastname = "San Juan", Email = "mark@skybest.com.ph", Username = "mackyboi", PasswordHash = "skyMark01", ApprovalStatus = ApprovalStatus.Pending, IsActive = true, Forgotpassword = (string?)null},
        //     new { Id = Guid.NewGuid(), Firstname = "Joshua", Lastname = "Suba", Email = "joshua.suba@skybest.com.ph", Username = "jsuba", PasswordHash = "skyJoshua01", ApprovalStatus = ApprovalStatus.Pending, IsActive = true, Forgotpassword = (string?)null},
        //     new { Id = Guid.NewGuid(), Firstname = "Norwin", Lastname = "Nabong", Email = "norwin.nabong@skybest.com.ph", Username = "nnabong", PasswordHash = "skyNorwin01", ApprovalStatus = ApprovalStatus.Pending, IsActive = true, Forgotpassword = (string?)null},
        //     new { Id = Guid.NewGuid(), Firstname = "Dan Cedrick", Lastname = "Dela Torre", Email = "dan.delatorre@skybest.com.ph", Username = "DTorre", PasswordHash = "skyDan01", ApprovalStatus = ApprovalStatus.Pending, IsActive = true, Forgotpassword = (string?)null}
        // );

        modelBuilder.Entity<Log>()
       .Property(b => b.Datetime)
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }

}

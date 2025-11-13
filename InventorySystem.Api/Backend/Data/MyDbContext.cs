using System;
using System.Collections.Generic;
using Backend.Entities.Users;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public DbSet<Tbl_Users> Tbl_Users { get; set; }
    public DbSet<Tbl_Access> Tbl_Access { get; set; }
    public DbSet<Tbl_Grant_Access> Tbl_Grant_Access { get; set; }
    public DbSet<Tbl_Logs> Tbl_Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tbl_Access>().HasData(
            new { Id = 1, Access = "View Module 1" },
            new { Id = 2, Access = "Add Module 1" },
            new { Id = 3, Access = "Edit Module 1" }
        );

        modelBuilder.Entity<Tbl_Logs>()
       .Property(b => b.Datetime)
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }

}

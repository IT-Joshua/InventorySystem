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

        modelBuilder.Entity<Tbl_Users>().HasData(
            new { Id = 1, Firstname = "Mark", Lastname = "San Juan", Email = "mark@skybest.com.ph", Username = "mackyboi", Password = "skyMark01", Access = "SuperAdmin", Status = true },
            new { Id = 2, Firstname = "Joshua", Lastname = "Suba", Email = "joshua.suba@skybest.com.ph", Username = "jsuba", Password = "skyJoshua01", Access = "SuperAdmin", Status = true },
            new { Id = 3, Firstname = "Norwin", Lastname = "Nabong", Email = "norwin.nabong@gmail.com.ph", Username = "nnabong", Password = "skyNorwin01", Access = "SuperAdmin", Status = true },
            new { Id = 4, Firstname = "Dan Cedrick", Lastname = "Dela Torre", Email = "dan.delatorre@skybest.com.ph", Username = "DTorre", Password = "skyDan01", Access = "SuperAdmin", Status = true }
        );

        modelBuilder.Entity<Tbl_Logs>()
       .Property(b => b.Datetime)
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }

}

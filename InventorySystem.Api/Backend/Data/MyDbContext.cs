using System;
using System.Collections.Generic;
using Backend.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public DbSet<Tbl_Users> Tbl_Users { get; set; }
    public DbSet<Tbl_Access> Tbl_Access { get; set; }
    public DbSet<Tbl_Assigned_Access> Tbl_Assigned_Access { get; set; }
    public DbSet<Tbl_Logs> Tbl_Logs { get; set; }
    
}

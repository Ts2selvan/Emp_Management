using EMP_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EMP_Management.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Employees> Employee { get; set; }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employees>(entity =>
        //    {
        //        entity.ToTable("employees");
        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.Email).HasColumnName("email");
        //        entity.Property(e => e.Password).HasColumnName("password");


        //    });
        //}

    }
}

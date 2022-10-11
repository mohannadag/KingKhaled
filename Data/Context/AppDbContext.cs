using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // General
        public DbSet<Nationality> Nationalities { get; set; }

        // Financial
        public DbSet<Bank> Banks { get; set; }
        public DbSet<JobGroup> JobGroups { get; set; }
        public DbSet<Job> Jobs { get; set; }

        // Identifications
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }

        public DbSet<Identity> Identities { get; set; }
        public DbSet<Passport> Passports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Set EmployeeId and BankId as Principle Key[Index].
            builder.Entity<EmployeeAccount>()
            .HasIndex(x => new { x.EmployeeId, x.BankId })
            .IsUnique(true);
        }
    }
}

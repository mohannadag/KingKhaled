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

        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Identity> Identities { get; set; }
    }
}

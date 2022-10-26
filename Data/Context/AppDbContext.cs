﻿using Core.Enums;
using Core.Models.Allowance;
using Core.Models.EmployeesInfo;
using Core.Models.EmploymentApplications;
using Core.Models.Financial;
using Core.Models.General;
using Core.Models.Jobs;

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
        // Allowances
        public DbSet<AllowanceType> AllowanceTypes { get; set; }

        // General
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<JobVacancy> JobVacancies { get; set; }
        // Financial
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<JobVisa> JobVisas { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobGroup> JobGroups { get; set; }
        public DbSet<JobSubGroup> JobSubGroups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        // Identifications
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Passport> Passports { get; set; }

        //Employment Applications
        public DbSet<EmploymentApplications> EmploymentApplications { get;set;}

    protected override void OnModelCreating(ModelBuilder builder)
        {
            // ManyToMany [Full-Configurations] between Grade and Level [Salary]
            builder.Entity<Grade>()
                   .HasMany(x => x.Levels)
                   .WithMany(x => x.Grades)
                   .UsingEntity<Salary>(
                       j => j
                                .HasOne(x => x.Level)
                                .WithMany(x => x.Salaries)
                                .HasForeignKey(x => x.LevelId),
                        j => j
                                .HasOne(x => x.Grade)
                                .WithMany(x => x.Salaries)
                                .HasForeignKey(x => x.GradeId),
                        j =>
                        {
                            j.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
                            //j.HasKey(x => new { x.LevelId, x.GradeId });
                            j.HasKey(x => new { x.Id });
                            j.Property(x => x.Id).ValueGeneratedOnAdd();
                        }
                    );

            // ManyToMany [Full-Configurations] between Job and Grade [JobGrade]
            builder.Entity<Job>()
                   .HasMany(x => x.Grades)
                   .WithMany(x => x.Jobs)
                   .UsingEntity<JobGrade>(
                       j => j
                                .HasOne(x => x.Grade)
                                .WithMany(x => x.JobGrades)
                                .HasForeignKey(x => x.GradeId),
                        j => j
                                .HasOne(x => x.Job)
                                .WithMany(x => x.JobGrades)
                                .HasForeignKey(x => x.JobId),
                        j =>
                        {
                            j.Property(x => x.AddedDate).HasDefaultValueSql("GETDATE()");
                            j.HasKey(x => new { x.JobId, x.GradeId });
                            j.Property(x => x.Id).ValueGeneratedOnAdd();
                        }
                    );

            //// ManyToMany in EF5 between Job and Grade with [JobGrade]
            //builder.Entity<Job>()
            //       .HasMany(x => x.Grades)
            //       .WithMany(x => x.Jobs)
            //       .UsingEntity<JobGrade>(
            //           x => x.HasOne<Grade>().WithMany().HasForeignKey(x => x.GradeId),
            //           x => x.HasOne<Job>().WithMany().HasForeignKey(x => x.JobId))
            //       .Property(x => x.AddedDate)
            //       .HasDefaultValueSql("GETDATE()");

            //// Set Id as Principle Key[Index].
            //builder.Entity<JobGrade>()
            //.HasIndex(x => new { x.Id })
            //.IsUnique(true);

            // Set VacantNumber as Principle Key[Index].
            builder.Entity<JobVacancy>()
            .HasIndex(x => new { x.VacantNumber })
            .IsUnique(true);

            // Set GradeNumber as Principle Key[Index].
            builder.Entity<Grade>()
            .HasIndex(x => new { x.GradeNumber })
            .IsUnique(true);

            // Set LevelNumber as Principle Key[Index].
            builder.Entity<Level>()
            .HasIndex(x => new { x.LevelNumber })
            .IsUnique(true);

            // Set EmployeeId and BankId as Principle Key[Index].
            builder.Entity<EmployeeAccount>()
            .HasIndex(x => new { x.EmployeeId, x.BankId })
            .IsUnique(true);

            // OneToMany between MinGrade and Job.
            builder.Entity<Job>()
            .HasOne(s => s.MinGrade)
            .WithMany(g => g.MinGradeJobs)
            .HasForeignKey(s => s.MinGradeId)
            .OnDelete(DeleteBehavior.Restrict);

            // OneToMany between MaxGrade and Job.
            builder.Entity<Job>()
            .HasOne(s => s.MaxGrade)
            .WithMany(g => g.MaxGradeJobs)
            .HasForeignKey(s => s.MaxGradeId)
            .OnDelete(DeleteBehavior.Restrict);

            // OneToOne between JobVacancy and Employee.
            builder.Entity<JobVacancy>()
            .HasOne(x => x.Employee)
            .WithOne(x => x.JobVacancy)
            .HasForeignKey<Employee>(x => x.JobVacancyId);

            

            
        }
    }
}

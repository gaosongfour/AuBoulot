using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AuBoulot.Web.Models;

namespace AuBoulot
{
    public class AuBoulotContext : DbContext
    {
        public AuBoulotContext(DbContextOptions<AuBoulotContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies {get;set;}
        public DbSet<JobOpportunity> JobOpportunities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<JobOpportunity>().ToTable("JobOpportunity");
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<Address>().ToTable("Address");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LIN;Database=AuBoulot;Trusted_Connection=True;");
        }
    }
}

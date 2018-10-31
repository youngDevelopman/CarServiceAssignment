using CarServiceAssignment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarServiceAssignment.DAL.EF
{
    public class CarServiceContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Data seeding
            modelBuilder.Entity<Car>().HasData(
                new { Id = 1, Brand = "BMW", Model = "X6", Type = "Heavyweight", Price = 10000.9m, Year = DateTime.Now });

            // Relationships between tables
            modelBuilder.Entity<CarOwner>().
                HasKey(t => new { t.CarId,t.OwnerId });

            modelBuilder.Entity<CarOwner>()
                .HasOne(sc => sc.Car)
                .WithMany(c => c.CarOwners)
                .HasForeignKey(sc => sc.CarId);

            modelBuilder.Entity<CarOwner>()
                .HasOne(sc => sc.Owner)
                .WithMany(c => c.CarOwners)
                .HasForeignKey(sc => sc.CarId);

        }
    }
}

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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Relationships between tables
            modelBuilder.Entity<Car>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Car>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CarOwner>().
                HasKey(t => new { t.CarId,t.OwnerId });

            modelBuilder.Entity<CarOwner>()
                .HasOne(sc => sc.Car)
                .WithMany(c => c.CarOwners)
                .HasForeignKey(sc => sc.CarId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarOwner>()
                .HasOne(sc => sc.Owner)
                .WithMany(c => c.CarOwners)
                .HasForeignKey(sc => sc.OwnerId).OnDelete(DeleteBehavior.Cascade);

            // Data seeding
            modelBuilder.Entity<Car>().HasData(
                new { Id = 1, Brand = "BMW", Model = "X6", Type = "Passenger car", Price = 10000.9m, Year = DateTime.Now },
                 new { Id = 2, Brand = "Mercedez", Model = "CLS", Type = "Passenger car", Price = 12000.0m, Year = DateTime.Now },
                 new { Id = 3, Brand = "Audi", Model = "A5", Type = "Passenger car", Price = 23000.0m, Year = DateTime.Now },
                 new { Id = 4, Brand = "Hodna", Model = "Sivic", Type = "Passenger car", Price = 9000.0m, Year = DateTime.Now },
                 new { Id = 5, Brand = "Volgswagen", Model = "WGI", Type = "Passenger car", Price = 10000.0m, Year = DateTime.Now },
                 new { Id = 6, Brand = "Kia", Model = "Soul", Type = "Passenger car", Price = 70000.0m, Year = DateTime.Now },
                 new { Id = 7, Brand = "Lada", Model = "Kalina", Type = "Passenger car", Price = 22800.0m, Year = DateTime.Now });

            modelBuilder.Entity<Owner>().HasData(
               new { Id = 1, FirstName = "John", LastName = "Marston", Birthdate = new DateTime(1980, 3, 20), DrivingExperience = "5-10 years" },
               new { Id = 2, FirstName = "Bill", LastName = "Gates", Birthdate = new DateTime(1980, 3, 20), DrivingExperience = "less than a 1 year" },
               new { Id = 3, FirstName = "Chris ", LastName = "Sanford", Birthdate = new DateTime(1980, 3, 20), DrivingExperience = "less than a 1 year" },
               new { Id = 4, FirstName = "Sam", LastName = "Houser", Birthdate = new DateTime(1980, 3, 20), DrivingExperience = "10-15 years" });

        }
    }
}

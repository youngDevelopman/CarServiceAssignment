using CarServiceAssignment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}

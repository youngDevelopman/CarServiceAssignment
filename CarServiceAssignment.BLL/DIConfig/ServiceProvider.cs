using CarServiceAssignment.BLL.Interfaces;
using CarServiceAssignment.BLL.Services;
using CarServiceAssignment.DAL.EF;
using CarServiceAssignment.DAL.Interfaces;
using CarServiceAssignment.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CarServiceAssignment.BLL.DIConfig
{
    public static class ServiceProvider
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IOwnerService, OwnerService>();
        }

        public static void AddDalServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CarServiceContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<CarServiceContext>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}

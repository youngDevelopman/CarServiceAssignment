﻿using CarServiceAssignment.DAL.DbExtentions;
using CarServiceAssignment.DAL.EF;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarServiceAssignment.DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private CarServiceContext db;

        public CarRepository(CarServiceContext context)
        {
            this.db = context;
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
                db.Cars.Remove(car);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return db.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            var car = db.Cars.Include(o => o.CarOwners).ThenInclude(c => c.Owner).ToList().SingleOrDefault(o => o.Id == id);
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            var car = db.Cars.Include(o => o.CarOwners).ThenInclude(c => c.Owner).ToList();
            return car;
        }

        public void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }
    }
} 

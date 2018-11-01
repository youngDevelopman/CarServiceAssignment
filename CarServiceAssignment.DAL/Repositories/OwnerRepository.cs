
using CarServiceAssignment.DAL.EF;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OwnerServiceAssignment.DAL.Repositories
{
    public class OwnerRepository: IRepository<Owner> 
    {
        private CarServiceContext db;

        public OwnerRepository(CarServiceContext context)
        {
            this.db = context;
        }

        public void Create(Owner car)
        {
            db.Owners.Add(car);
        }

        public void Delete(int id)
        {
            Owner car = db.Owners.Find(id);
            if (car != null)
                db.Owners.Remove(car);
        }

        public IEnumerable<Owner> Find(Func<Owner, bool> predicate)
        {
            return db.Owners.Where(predicate).ToList();
        }

        public Owner Get(int id)
        {
            return db.Owners.Find(id);
        }

        public IEnumerable<Owner> GetAll()
        {
            var owners = db.Owners.Include(o => o.CarOwners).ThenInclude(c => c.Car).ToList();
            return owners;
        }

        public void Update(Owner car)
        {
            db.Entry(car).State = EntityState.Modified;
        }
    }
}

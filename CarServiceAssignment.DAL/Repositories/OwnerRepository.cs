
using CarServiceAssignment.DAL.DbExtentions;
using CarServiceAssignment.DAL.EF;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OwnerServiceAssignment.DAL.Repositories
{
    public class OwnerRepository: IOwnerRepository 
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

        public void DeleteCarOwner(int ownerId, int carId)
        {
            var owner = this.Get(ownerId);
            var carToDelete = owner.CarOwners.Where(c => c.CarId == carId).SingleOrDefault();
            owner.CarOwners.Remove(carToDelete);
            db.SaveChanges();
        }

        public IEnumerable<Owner> Find(Func<Owner, bool> predicate)
        {
            return db.Owners.Where(predicate).ToList();
        }

        public Owner Get(int id)
        {
            var owner = db.Owners.Include(o => o.CarOwners).ThenInclude(c => c.Car).ToList().SingleOrDefault(o => o.Id == id);
            return owner;
        }

        public IEnumerable<Owner> GetAll()
        {
            var owners = db.Owners.Include(o => o.CarOwners).ThenInclude(c => c.Car).ToList();
            return owners;
        }

        public void Update(Owner owner)
        {
            db.Entry(owner).State = EntityState.Modified;
        }

        public void Update(int ownerId, int carId)
        {
            var owner = db.Owners.Include(x => x.CarOwners).Where(x => x.Id == ownerId).FirstOrDefault();

            foreach (var car in owner.CarOwners)
            {
                if (car.CarId == carId)
                {
                    return;
                }
            }
            //if(owner.CarOwners.)
            var carOwner = new CarOwner()
            {
                Car = db.Cars.Find(carId),
                Owner = db.Owners.Find(ownerId),
                CarId = carId,
                OwnerId = ownerId
            };

           
            owner.CarOwners.Add(carOwner);
            this.Update(owner);
            db.SaveChanges();
        }
    }
}

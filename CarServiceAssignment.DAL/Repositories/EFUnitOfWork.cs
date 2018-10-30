using CarServiceAssignment.DAL.EF;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using OwnerServiceAssignment.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CarServiceContext db;
        private CarRepository carRepository;
        private OwnerRepository ownerRepository;

        public EFUnitOfWork(CarServiceContext context)
        {
            this.db = context;
        }

        public IRepository<Car> Cars
        {
            get
            {
                if(carRepository == null)
                {
                    carRepository = new CarRepository(db);
                }
                return carRepository;
            }
        }

        public IRepository<Owner> Owners
        {
            get
            {
                if (ownerRepository == null)
                {
                    ownerRepository = new OwnerRepository(db);
                }
                return ownerRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

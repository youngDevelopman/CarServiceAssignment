using CarServiceAssignment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.DAL.Interfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        void Update(int ownerId, int carId);
        void DeleteCarOwner(int ownerId, int carId);
    }
}

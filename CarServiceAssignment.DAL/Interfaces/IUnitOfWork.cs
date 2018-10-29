using CarServiceAssignment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Owner> Owners { get;}
        void Save();
    }
}

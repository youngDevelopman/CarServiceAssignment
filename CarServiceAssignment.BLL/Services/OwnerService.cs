using AutoMapper;
using CarServiceAssignment.BLL.DTO;
using CarServiceAssignment.BLL.Interfaces;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.BLL.Services
{
    public class OwnerService : IOwnerService
    {
        IUnitOfWork Database { get; set; }

        public OwnerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<OwnerDTO> GetOwners()
        {
            IEnumerable<OwnerDTO> ownerDTO = Mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerDTO>>(Database.Owners.GetAll());

            return ownerDTO;
        }

        public void UpdateOwnerInfo(OwnerDTO ownerDTO)
        {
            Owner updatedOwner = Mapper.Map<OwnerDTO, Owner>(ownerDTO);
            Database.Owners.Update(updatedOwner);
            Database.Save();
        }

        public void DeleteOwner(int id)
        {
            Database.Owners.Delete(id);
            Database.Save();
        }

        public void CreateOwner(OwnerDTO ownerDTO)
        {
            Owner updatedOwner = Mapper.Map<OwnerDTO, Owner>(ownerDTO);
            Database.Owners.Create(updatedOwner);
            Database.Save();
        }

        public void AddCarForOwner(int ownerId, int carId)
        {
            Database.Owners.Update(ownerId, carId);
        }
    }
}

using CarServiceAssignment.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.BLL.Interfaces
{
    public interface IOwnerService
    {
        IEnumerable<OwnerDTO> GetOwners();
        void UpdateOwnerInfo(OwnerDTO ownerDTO);
        void DeleteOwner(int id);
        void CreateOwner(OwnerDTO ownerDTO);
    }
}

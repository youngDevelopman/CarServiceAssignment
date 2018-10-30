using CarServiceAssignment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.BLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }

        public ICollection<OwnerDTO> CarOwners { get; set; }
    }
}

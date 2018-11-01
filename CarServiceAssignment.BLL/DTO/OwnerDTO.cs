using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.BLL.DTO
{
    public class OwnerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string DrivingExperience { get; set; }


        public ICollection<CarDTO> CarOwners { get; set; }
    }
}

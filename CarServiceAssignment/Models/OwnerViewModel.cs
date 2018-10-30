using System;
using System.Collections.Generic;

namespace CarServiceAssignment.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DrivingExperience { get; set; }

        public virtual ICollection<CarViewModel> Cars { get; set; }
    }
}
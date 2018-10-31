using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceAssignment.Models
{
    public class OwnerViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DrivingExperience { get; set; }

        public virtual ICollection<CarViewModel> CarOwners { get; set; }
    }
}
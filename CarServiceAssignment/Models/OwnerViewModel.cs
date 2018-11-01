using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceAssignment.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }

        [Required]
        public string DrivingExperience { get; set; }

        public virtual ICollection<CarViewModel> CarOwners { get; set; }
    }
}
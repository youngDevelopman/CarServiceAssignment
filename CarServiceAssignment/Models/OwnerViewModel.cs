using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceAssignment.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter the correct first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, enter the correct last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, enter the correct birthdate")]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "Please, enter the correct driving experience")]
        public string DrivingExperience { get; set; }

        public virtual ICollection<CarViewModel> CarOwners { get; set; }
    }
}
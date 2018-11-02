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
        [Display(Name = "Fisrt name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, enter the correct last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, enter the correct birthdate")]
        [Display(Name = "Date of birth")]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "Please, enter the correct driving experience")]
        [Display(Name = "Driving experience")]
        public string DrivingExperience { get; set; }

        [Display(Name = "Which car he/she has")]
        public virtual ICollection<CarViewModel> CarOwners { get; set; }
    }
}
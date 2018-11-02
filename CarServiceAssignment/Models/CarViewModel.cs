using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceAssignment.Models
{
    public class CarViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Please, enter the correct brand name")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please, enter the correct model name")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please, enter the correct type")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please, enter the correct price")]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage ="Please,enter the correct year")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Year")]
        public DateTime? Year { get; set; }

        public  ICollection<OwnerViewModel> CarOwners { get; set; }
    }
}

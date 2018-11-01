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
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please, enter the correct model name")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please, enter the correct type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please, enter the correct price")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage ="Please,enter the correct year")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Year { get; set; }

        public virtual ICollection<OwnerViewModel> CarOwners { get; set; }

        public CarViewModel()
        {
            CarOwners = new List<OwnerViewModel>();
        }
    }
}

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

        [Required(ErrorMessage ="Please, enter the brand name")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please, enter the model name")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please, enter the type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please, enter the Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Please,enter the year")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Year { get; set; }

        public virtual ICollection<OwnerViewModel> CarOwners { get; set; }

        public CarViewModel()
        {
            CarOwners = new List<OwnerViewModel>();
        }
    }
}

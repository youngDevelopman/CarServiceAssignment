using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceAssignment.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }

        public virtual ICollection<OwnerViewModel> CarOwners { get; set; }
    }
}

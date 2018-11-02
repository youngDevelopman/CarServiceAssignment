using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarServiceAssignment.DAL.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }

        public  ICollection<CarOwner> CarOwners { get; set; }

        public Car()
        {
            CarOwners = new List<CarOwner>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }

        public virtual ICollection<Owner> Owners { get; set; }

        public Car()
        {
            Owners = new List<Owner>();
        }
    }
}

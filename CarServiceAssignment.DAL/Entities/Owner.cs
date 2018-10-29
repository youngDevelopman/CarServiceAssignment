using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.DAL.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DrivingExperience { get; set; }


        public virtual ICollection<Car> Cars { get; set; }

        public Owner()
        {
            Cars = new List<Car>();
        }
    }
}

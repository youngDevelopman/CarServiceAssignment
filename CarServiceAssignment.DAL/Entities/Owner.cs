using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarServiceAssignment.DAL.Entities
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string DrivingExperience { get; set; }


        public ICollection<CarOwner> CarOwners { get; set; }

        public Owner()
        {
            CarOwners = new List<CarOwner>();
        }
    }
}

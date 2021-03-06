﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarServiceAssignment.DAL.Entities
{
    public class CarOwner
    {
        
        public int? CarId { get; set; }
        public Car Car { get; set; }

        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}

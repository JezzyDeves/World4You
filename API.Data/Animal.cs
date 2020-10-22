﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
    public class Animal
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Species { get; set; }
        public int Population { get; set; }
        //Add Location
    }
}
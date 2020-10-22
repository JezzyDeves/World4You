﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.PlaceModels
{
    public class PlaceCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        public int Elevation { get; set; }
        public string Climate { get; set; }
    }
}
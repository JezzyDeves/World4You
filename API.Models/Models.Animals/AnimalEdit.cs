﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Models.Animals
{
    public class AnimalEdit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Population { get; set; }

        public int PlaceID { get; set; }
        public int? EquippedArtifact { get; set; }
    }
}

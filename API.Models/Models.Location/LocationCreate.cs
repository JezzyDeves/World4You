using API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Models.Location
{
    public class LocationCreate
    {
        public string Name { get; set; }

        public string SpecificLocation { get; set; }

        public int PlaceID { get; set; }
        
    }
}

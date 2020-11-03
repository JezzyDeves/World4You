using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Models.Location
{
    public class LocationListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public string SpecificLocation { get; set; }
       
        public int PlaceID { get; set; }

        public virtual Place Place { get; set; }
    }
}

using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Models.Artifacts
{
    public class ArtifactDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public Place Location { get; set; }
    }
}

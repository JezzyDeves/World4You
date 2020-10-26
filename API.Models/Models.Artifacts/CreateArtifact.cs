using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Models.Artifacts
{
    public class CreateArtifact
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public int PlaceID { get; set; }
    }
}

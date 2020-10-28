using API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class PersonCreate
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public int Place { get; set; }
        public int? EquippedArtifact { get; set; }
    }
}

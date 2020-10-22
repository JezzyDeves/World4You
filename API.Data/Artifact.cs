using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
    public class Artifact
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        public string Power { get; set; }
        public string Description { get; set; }
        //Add Location
    }
}

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
        //[Key]
        public int ID { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Title { get; set; }
        //[Required]
        public int Age { get; set; }
        public string Occupation { get; set; }
        //Add Location
        //[ForeignKey(nameof(Place))]
        public virtual Place Place { get; set; }
    }
}

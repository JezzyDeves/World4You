using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Title { get; set; }
        [Required]
        public int Age { get; set; }
        public string Occupation { get; set; }
        //Add Location
    }
}

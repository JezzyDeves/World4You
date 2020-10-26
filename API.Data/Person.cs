using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public string Occupation { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        //Add Location
        [ForeignKey(nameof(Place))]
        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        public string Name { get; set; }
        [Required]
        public string SpecificLocation { get; set; }

        [ForeignKey(nameof(Place))]
        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }
    }
}

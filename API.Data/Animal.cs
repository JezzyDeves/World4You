using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
    public class Animal
    {
        
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Species { get; set; }
        public int Population { get; set; }

        public Guid OwnerID { get; set; }
        
        [ForeignKey(nameof(Place))]
        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }

        public int? EquippedArtifact { get; set; }
        [ForeignKey(nameof(EquippedArtifact))]
        public virtual Artifact Artifact { get; set; }
    }
}

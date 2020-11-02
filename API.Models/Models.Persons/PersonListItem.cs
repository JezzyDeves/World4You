using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Models.Persons
{
    public class PersonListItem
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public virtual Place Place { get; set; }
    }
}

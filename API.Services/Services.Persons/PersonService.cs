using API.Data;
using API.Models;
using API.Models.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Services.Persons
{
    public class  PersonService
    {
        private readonly Guid _userID;
        public PersonService(Guid userID)
        {
            _userID = userID;
        }
        public bool PersonCreate (PersonCreate model)
        {
            var entity =
                new Person()
                {
                    Name = model.Name,
                    Title = model.Title,
                    Age = model.Age,
                    Occupation = model.Occupation
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Persons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PersonListItem> GetPersons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Persons
                    .Where(e => e.OwnerID == _userID)
                    .Select(e => new PersonListItem
                    {
                        PersonID = e.ID,
                        Name = e.Name,} 
                    );
                return query.ToArray();
            }
        }
    }
}

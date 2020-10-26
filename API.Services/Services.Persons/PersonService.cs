using API.Data;
using API.Models;
using API.Models.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        //Create//
        public bool PersonCreate (PersonCreate model)
        {
            var entity =
                new Person()
                {  
                    //OwnerID = _userID Is this necessary?//
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
        //Get Person//
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
        //Get Person By Id//
        public PersonDetail GetPersonByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Persons
                    .Single(e => e.ID == id && e.OwnerID == _userID);
                return
                    new PersonDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Title = entity.Title,
                        Age = entity.Age,
                        Occupation = entity.Occupation
                    };
            }
        }//Update//
        public bool PersonUpdate(PersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Persons
                    .Single(e => e.ID == model.ID && e.OwnerID == _userID);
                entity.Name = model.Name;
                entity.Title = model.Title;
                entity.Age = model.Age;
                entity.Occupation = model.Occupation;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePerson(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Persons
                    .Single(e => e.ID == ID && e.OwnerID == _userID);
                ctx.Persons.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

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
    public class PersonService
    {
        private readonly Guid _userID;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public PersonService(Guid userID)
        {
            _userID = userID;
        }
        //Create//
        public bool PersonCreate(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    OwnerID = _userID,
                    Name = model.Name,
                    Title = model.Title,
                    Age = model.Age,
                    Occupation = model.Occupation,
                    PlaceID = model.Place,
                    EquippedArtifact = model.EquippedArtifact
                };
            _context.Persons.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //Get Person//
        public List<PersonListItem> GetPersons()
        {
            var query = _context.Persons
                .Where(e => e.OwnerID == _userID)
                .Select(e => new PersonListItem
                {
                    PersonID = e.ID,
                    Name = e.Name
                }
                );
            return query.ToList();
        }
        //Get Person By Id//
        public PersonDetail GetPersonByID(int id)
        {
            var entity = _context
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
        }//Update//
        public bool PersonUpdate(PersonEdit model)
        {
            var entity = _context
                .Persons
                .Single(e => e.ID == model.ID && e.OwnerID == _userID);
            entity.Name = model.Name;
            entity.Title = model.Title;
            entity.Age = model.Age;
            entity.Occupation = model.Occupation;
            return _context.SaveChanges() == 1;
        }
        public bool DeletePerson(int ID)
        {
            var entity = _context
                .Persons
                .Single(e => e.ID == ID && e.OwnerID == _userID);
            _context.Persons.Remove(entity);
            return _context.SaveChanges() == 1;
        }
    }
}

using API.Data;
using API.Models.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.AnimalServices
{
    public class AnimalServices
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userID;
        public AnimalServices(Guid userID)
        {
            _userID = userID;
        }

        //CREATE ENTRY/POST
        public bool AddAnimal(AnimalAdd model)
        {
            var entity = new Animal()
            {
                OwnerID = _userID,
                ID = model.ID,
                Name = model.Name,
                Species = model.Species,
                Population = model.Population,
                PlaceID = model.PlaceID
            };

            _context.Animals.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //READ ALL ENTRIES/GET ALL
        public List<AnimalDetail> GetAnimals()
        {
            var query =
                   _context.Animals.Where(e => e.OwnerID == _userID).Select(
                           e =>
                               new AnimalDetail()
                               {
                                   ID = e.ID,
                                   Name = e.Name,
                               }
                       );

            return query.ToList();
        }

        //READ BY ID/GET BY ID
        public AnimalDetail GetAnimalByID(int id)
        {
            var entity = _context.Animals.Single(e => e.ID == id && e.OwnerID == _userID);
           
            return
                new AnimalDetail
                {
                    Name = entity.Name,
                    Species = entity.Species,
                    Population = entity.Population,
                    Place = entity.Place
                };
        }

        //UPDATE ANIMAL INFO
        public bool UpdateAnimalInfo(AnimalDetail editModel)
        {
            var animalEntity = _context.Animals.Single(p => p.ID == editModel.ID && p.OwnerID == _userID);

            animalEntity.Name = editModel.Name;
            animalEntity.Species = editModel.Species;
            animalEntity.Population = editModel.Population;
            animalEntity.PlaceID = editModel.PlaceID;

            return _context.SaveChanges() == 1;
        }

        //DELETE ANIMAL
        public bool DeleteAnimal(int id)
        {
            var animalEntity = _context.Animals.Single(p => p.ID == id);
            _context.Animals.Remove(animalEntity);

            return _context.SaveChanges() == 1;
        }
    }
}

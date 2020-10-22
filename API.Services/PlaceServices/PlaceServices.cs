using API.Data;
using API.Models;
using API.Models.PlaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class PlaceServices
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        //POST
        public bool CreatePlace(PlaceCreate model)
        {
            Place entity = new Place
            {
                Name = model.Name,
                Position = model.Position,
                Elevation = model.Elevation,
                Climate = model.Climate
            };

            _context.Places.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //GET ALL PLACES
        public List<PlaceDetail> ShowAllPlaces()
        {
            var placeEntities = _context.Places.ToList();
            var placeList = placeEntities.Select(p => new PlaceDetail
            {
                ID = p.ID,
                Name = p.Name,
                Position = p.Position,
                Elevation = p.Elevation,
                Climate = p.Climate
            }).ToList();

            return placeList;
        }

        //GET PLACES BY CLIMATE
        //UPDATE
        //DELETE
    }
}

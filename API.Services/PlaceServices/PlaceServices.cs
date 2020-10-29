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
        private readonly Guid _userID;
        public PlaceServices(Guid userID)
        {
            _userID = userID;
        }
        
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
        public List<PlaceListItem> ShowAllPlaces()
        {
            var placeEntities = _context.Places.ToList();
            var placeList = placeEntities.Select(p => new PlaceListItem
            {
                ID = p.ID,
                Name = p.Name,
                Position = p.Position,
                Elevation = p.Elevation,
                Climate = p.Climate
            }).ToList();

            return placeList;
        }

        //GET PLACES BY ID
        public PlaceDetail ShowPlacesByID(int id)
        {
            var placeEntity = _context.Places.Single(e => e.ID == id);
            return new PlaceDetail
            {
                ID = placeEntity.ID,
                Name = placeEntity.Name,
                Position = placeEntity.Position,
                Elevation = placeEntity.Elevation,
                Climate = placeEntity.Climate
            };
        }

        //UPDATE DETAILS ABOUT A PLACE
        public bool ChangePlaceInfo(PlaceEdit placeEdit)
        {
                var placeEntity = _context.Places.Single(p => p.ID == placeEdit.ID);

                placeEntity.Name = placeEdit.Name;
                placeEntity.Position = placeEdit.Position;
                placeEntity.Elevation = placeEdit.Elevation;
                placeEntity.Climate = placeEdit.Climate;

                return _context.SaveChanges() == 1;
        }

        //DELETE A PLACE
        public bool DeleteAPlace(int id)
        {
            var placeEntity =_context.Places.Single(p => p.ID == id);
            _context.Places.Remove(placeEntity);

            return _context.SaveChanges() == 1;
        }
    }
}

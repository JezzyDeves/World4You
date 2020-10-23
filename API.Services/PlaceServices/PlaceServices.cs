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
        public PlaceDetail ShowAllPlacesInClimate(string climate)
        {
            var placeEntity = _context.Places.Find(climate);
            var placeDetail = new PlaceDetail
            {
                ID = placeEntity.ID,
                Name = placeEntity.Name,
                Position = placeEntity.Position,
                Elevation = placeEntity.Elevation,
                Climate = placeEntity.Climate
            };

            return placeDetail;
        }

        //UPDATE DETAILS ABOUT A PLACE
        public bool ChangePlaceInfo(PlaceDetail placeDetail)
        {
                var placeEntity = _context.Places.Single(p => p.ID == placeDetail.ID);

                placeEntity.Name = placeDetail.Name;
                placeEntity.Position = placeDetail.Position;
                placeEntity.Elevation = placeDetail.Elevation;
                placeEntity.Climate = placeDetail.Climate;

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

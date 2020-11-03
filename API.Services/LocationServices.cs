using API.Data;
using API.Models.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class LocationServices
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userID;

        public LocationServices(Guid userID)
        {
            _userID = userID;
        }

        //CREATE A LOCATION
        public bool CreateLocation(LocationCreate model)
        {
            Location location = new Location()
            {
                OwnerID = _userID,
                Name = model.Name,
                SpecificLocation = model.SpecificLocation,
                PlaceID = model.PlaceID
            };

            _context.Locations.Add(location);
            return _context.SaveChanges() == 1;
        }

        //SHOW ALL LOCATIONS
        public List<LocationListItem> ShowAllLocations()
        {
            var locationEntities = _context.Locations.ToList();
            var placeList = locationEntities.Select(p => new LocationListItem
            {
                ID = p.ID,
                Name = p.Name,
                SpecificLocation = p.SpecificLocation,
                PlaceID = p.PlaceID,
                Place = p.Place
            }).ToList();

            return placeList;
        }

        //SHOW LOCATIONS BY ID
        public LocationDetail ShowLocationsByID(int id)
        {
            var locationEntity = _context.Locations.Single(e => e.ID == id);
            return new LocationDetail
            {
                ID = locationEntity.ID,
                Name = locationEntity.Name,
                SpecificLocation = locationEntity.SpecificLocation,
                PlaceID = locationEntity.PlaceID,
                Place = locationEntity.Place
            };
        }

        //UPDATE LOCATION INFO
        public bool ChangeLocationInfo(LocationEdit locationEdit)
        {
            var locationEntity = _context.Locations.Single(p => p.ID == locationEdit.ID);

            
            locationEntity.Name = locationEdit.Name;
            locationEntity.SpecificLocation = locationEdit.SpecificLocation;
            locationEntity.PlaceID = locationEdit.PlaceID;
            locationEntity.Place = locationEdit.Place;

            return _context.SaveChanges() == 1;
        }

        //DELETE A LOCATION
        public bool DeleteALocation(int id)
        {
            var locationEntity = _context.Locations.Single(p => p.ID == id);
            _context.Locations.Remove(locationEntity);

            return _context.SaveChanges() == 1;
        }
    }
}

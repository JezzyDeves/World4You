using API.Models.Models.Location;
using API.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace World4YouAPI.Controllers
{
    
    public class LocationController : ApiController
    {
        private LocationServices CreateLocationService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationServices(userID);
            return locationService;
        }

        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            LocationServices service = CreateLocationService();
            var locations = service.ShowAllLocations();
            return Ok(locations);
        }

        public IHttpActionResult Get(int id)
        {
            LocationServices locationService = CreateLocationService();
            var location = locationService.ShowLocationsByID(id);
            return Ok(location);
        }
        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateLocationService();
            if (!service.ChangeLocationInfo(location))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int ID)
        {
            var service = CreateLocationService();
            if (!service.DeleteALocation(ID))
                return InternalServerError();
            return Ok();
        }

    }
}

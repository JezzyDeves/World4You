using API.Models;
using API.Services;
using API.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.PlaceModels;

namespace World4YouAPI.Controllers
{
    [Authorize]
    public class PlacesController : ApiController
    {
        private PlaceServices CreatePlaceService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var placeService = new PlaceServices(userID);
            return placeService;
        }

        public IHttpActionResult Get()
        {
            PlaceServices service = CreatePlaceService();
            var places = service.ShowAllPlaces();
            return Ok(places);
        }
        
        public IHttpActionResult Post(PlaceCreate place)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaceService();

            if (!service.CreatePlace(place))
                return InternalServerError();

            return Ok();
        }
    }
}

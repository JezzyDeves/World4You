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

        public IHttpActionResult Get(int id)
        {
            PlaceServices placeService = CreatePlaceService();
            var place = placeService.ShowPlacesByID(id);
            return Ok(place);
        }
        public IHttpActionResult Put(PlaceEdit place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePlaceService();
            if (!service.ChangePlaceInfo(place))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int ID)
        {
            var service = CreatePlaceService();
            if (!service.DeleteAPlace(ID))
                return InternalServerError();
            return Ok();
        }
    }
}

using API.Models.Models.Animals;
using API.Services.AnimalServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace World4YouAPI.Controllers
{
    public class AnimalController : ApiController
    {
        private AnimalServices CreateAnimalService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var animalService = new AnimalServices(userID);
            return animalService;
        }

        public IHttpActionResult Get()
        {
            AnimalServices service = CreateAnimalService();
            var animals = service.GetAnimals();
            return Ok(animals);
        }

        public IHttpActionResult Post(AnimalAdd animal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAnimalService();

            if (!service.AddAnimal(animal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            AnimalServices animalService = CreateAnimalService();
            var person = animalService.GetAnimalByID(id);
            return Ok(person);
        }
        public IHttpActionResult Put(AnimalEdit animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateAnimalService();
            if (!service.UpdateAnimalInfo(animal))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int ID)
        {
            var service = CreateAnimalService();
            if (!service.DeleteAnimal(ID))
                return InternalServerError();
            return Ok();
        }
    }
}

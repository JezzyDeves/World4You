using API.Models;
using API.Models.Models.Persons;
using API.Services.Services.Persons;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace World4YouAPI.Controllers
{
    [Authorize]
    public class PersonController : ApiController
    {
        private PersonService CreatePersonService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var personService = new PersonService(userID);
            return personService;
        }
        public IHttpActionResult Get()
        {
            PersonService personService = CreatePersonService();
            var persons = personService.GetPersons();
            return Ok(persons);
        }
        public IHttpActionResult Post(PersonCreate person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                    
            var service = CreatePersonService();
            if (!service.PersonCreate(person))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            PersonService personService = CreatePersonService();
            var person = personService.GetPersonByID(id);
            return Ok(person);
        }
        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePersonService();
            if (!service.PersonUpdate(person))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int ID)
        {
            var service = CreatePersonService();
            if (!service.DeletePerson(ID))
                return InternalServerError();
            return Ok();
        }
       
    }
    
}

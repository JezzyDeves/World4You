using API.Models.Models.Artifacts;
using API.Services.ArtifactServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace World4YouAPI.Controllers
{
    [Authorize]
    public class ArtifactController : ApiController
    {
        private ArtifactService CreateArtifactService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var artifactService = new ArtifactService(userID);
            return artifactService;
        }

        public IHttpActionResult Get()
        {
            ArtifactService service = CreateArtifactService();
            var artifacts = service.GetArtifacts();
            return Ok(artifacts);
        }
        public IHttpActionResult Get(int id)
        {
            ArtifactService service = CreateArtifactService();
            var artifact = service.GetArtifactByID(id);
            return Ok(artifact);
        }
        public IHttpActionResult Post(CreateArtifact artifact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtifactService();

            if (!service.ArtifactCreate(artifact))
                return InternalServerError();

            return Ok();
        }
    }
}

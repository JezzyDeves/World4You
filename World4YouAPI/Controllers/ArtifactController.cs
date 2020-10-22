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
    }
}

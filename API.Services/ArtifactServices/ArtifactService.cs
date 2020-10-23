using API.Data;
using API.Models.Models.Artifacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.ArtifactServices
{
    public class ArtifactService
    {
        private readonly Guid _userID;

        public ArtifactService(Guid userID)
        {
            _userID = userID;
        }

        public bool ArtifactCreate(CreateArtifact model)
        {
            var entity = new Artifact()
            {
                Name = model.Name,
                Age = model.Age,
                Power = model.Power,
                Description = model.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artifacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArtifactListItem> GetArtifacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artifacts
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new ArtifactListItem
                                {
                                    ArtifactID = e.ID,
                                    Name = e.Name,
                                }
                        );

                return query.ToArray();
            }
        }
        public ArtifactDetail GetArtifactByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artifacts
                    .Single(e => e.ID == id && e.OwnerID == _userID);
                return
                    new ArtifactDetail
                    {
                        Name = entity.Name,
                        Age = entity.Age,
                        Power = entity.Power,
                        Description = entity.Description,
                        Location = entity.Place
                    };
            }
        }
    }
}

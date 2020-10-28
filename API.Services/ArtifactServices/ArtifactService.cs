using API.Data;
using API.Models.Models.Artifacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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
                OwnerID = _userID,
                Name = model.Name,
                Age = model.Age,
                Power = model.Power,
                Description = model.Description,
                PlaceID = model.PlaceID
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
        public ArtifactDetail GetArtifactByID([FromUri] int id)
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
                        ID = entity.ID,
                        Name = entity.Name,
                        Age = entity.Age,
                        Power = entity.Power,
                        Description = entity.Description,
                        Location = entity.Place
                    };
            }
        }
        public bool EditArtifact(ArtifactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artifacts
                    .Single(e => e.ID == model.ID && e.OwnerID == _userID);

                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Power = model.Power;
                entity.Description = model.Description;
                entity.PlaceID = model.PlaceID;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteArtifact(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artifacts
                    .Single(e => e.ID == id && e.OwnerID == _userID);
                ctx.Artifacts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

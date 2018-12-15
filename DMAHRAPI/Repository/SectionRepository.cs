using Data.Models;
using System.Linq;

namespace DMAHRAPI.Repository
{
    public class SectionRepository : RepositoryBase<Section>
    {
        public SectionRepository()
        {
            this.entityContext = new GovernmentDbContext();
        }
        public SectionRepository(GovernmentDbContext context)
        {
            this.entityContext = context;
        }
        protected override Section AddEntity(GovernmentDbContext entityContext, Section entity)
        {
            return entityContext.Sections.Add(entity);
        }
        protected override Section AddOrUpdateEntity(GovernmentDbContext entityContext, Section entity)
        {
            if (entity.SectionID == default(int))
            {
                return entityContext.Sections.Add(entity);
            }
            else
            {

                return entityContext.Sections.FirstOrDefault(e => e.SectionID == entity.SectionID);
            }
        }

        protected override Section UpdateEntity(GovernmentDbContext entityContext, Section entity)
        {
            return entityContext.Sections.FirstOrDefault(e => e.SectionID == entity.SectionID);

        }

        protected override IQueryable<Section> GetEntities()
        {
            return entityContext.Sections.AsQueryable();
        }
        protected override IQueryable<Section> GetEntitiesWithoutTracking()
        {
            return entityContext.Sections.AsNoTracking().AsQueryable();
        }

        protected override Section GetEntity(GovernmentDbContext entityContext, int id)
        {
            return entityContext.Sections.FirstOrDefault(e => e.SectionID == id);
        }


    }
}
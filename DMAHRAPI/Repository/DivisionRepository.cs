using Data.Models;
using System.Linq;

namespace DMAHRAPI.Repository
{
    public class DivisionRepository : RepositoryBase<Division>
    {
        public DivisionRepository()
        {
            this.entityContext = new GovernmentDbContext();
        }
        public DivisionRepository(GovernmentDbContext context)
        {
            this.entityContext = context;
        }
        protected override Division AddEntity(GovernmentDbContext entityContext, Division entity)
        {
            return entityContext.Divisions.Add(entity);
        }
        protected override Division AddOrUpdateEntity(GovernmentDbContext entityContext, Division entity)
        {
            if (entity.DivisionID == default(int))
            {
                return entityContext.Divisions.Add(entity);
            }
            else
            {

                return entityContext.Divisions.FirstOrDefault(e => e.DivisionID == entity.DivisionID);
            }
        }

        protected override Division UpdateEntity(GovernmentDbContext entityContext, Division entity)
        {
            return entityContext.Divisions.FirstOrDefault(e => e.DivisionID == entity.DivisionID);

        }

        protected override IQueryable<Division> GetEntities()
        {
            return entityContext.Divisions.AsQueryable();
        }
        protected override IQueryable<Division> GetEntitiesWithoutTracking()
        {
            return entityContext.Divisions.AsNoTracking().AsQueryable();
        }

        protected override Division GetEntity(GovernmentDbContext entityContext, int id)
        {
            return entityContext.Divisions.FirstOrDefault(e => e.DivisionID == id);
        }


    }
}
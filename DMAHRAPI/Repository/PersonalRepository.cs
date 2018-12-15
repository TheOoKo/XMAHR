using Data.Models;
using System.Linq;

namespace DMAHRAPI.Repository
{
    public class PersonalRepository : RepositoryBase<Personal>
    {
        public PersonalRepository()
        {
            this.entityContext = new GovernmentDbContext();
        }
        public PersonalRepository(GovernmentDbContext context)
        {
            this.entityContext = context;
        }
        protected override Personal AddEntity(GovernmentDbContext entityContext, Personal entity)
        {
            return entityContext.Personals.Add(entity);
        }
       
        protected override Personal AddOrUpdateEntity(GovernmentDbContext entityContext, Personal entity)
        {
            if (entity.PersonalID == default(int))
            {
                return entityContext.Personals.Add(entity);
            }
            else
            {

                return entityContext.Personals.FirstOrDefault(e => e.PersonalID == entity.PersonalID);
            }
        }

        protected override Personal UpdateEntity(GovernmentDbContext entityContext, Personal entity)
        {
            return entityContext.Personals.FirstOrDefault(e => e.PersonalID == entity.PersonalID);

        }

        protected override IQueryable<Personal> GetEntities()
        {
            return entityContext.Personals.AsQueryable();
        }
        protected override IQueryable<Personal> GetEntitiesWithoutTracking()
        {
            return entityContext.Personals.AsNoTracking().AsQueryable();
        }

        protected override Personal GetEntity(GovernmentDbContext entityContext, int id)
        {
            return entityContext.Personals.FirstOrDefault(e => e.PersonalID == id);
        }


    }
}
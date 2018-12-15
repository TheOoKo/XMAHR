using Data.Models;
using System.Linq;

namespace DMAHRAPI.Repository
{
    public class JobHistoryRepository : RepositoryBase<JobHistory>
    {
        public JobHistoryRepository()
        {
            this.entityContext = new GovernmentDbContext();
        }
        public JobHistoryRepository(GovernmentDbContext context)
        {
            this.entityContext = context;
        }
        protected override JobHistory AddEntity(GovernmentDbContext entityContext, JobHistory entity)
        {
            return entityContext.JobHistories.Add(entity);
        }

        protected override JobHistory AddOrUpdateEntity(GovernmentDbContext entityContext, JobHistory entity)
        {
            if (entity.PersonalID == default(int))
            {
                return entityContext.JobHistories.Add(entity);
            }
            else
            {

                return entityContext.JobHistories.FirstOrDefault(e => e.PersonalID == entity.PersonalID);
            }
        }

        protected override JobHistory UpdateEntity(GovernmentDbContext entityContext, JobHistory entity)
        {
            return entityContext.JobHistories.FirstOrDefault(e => e.PersonalID == entity.PersonalID);

        }

        protected override IQueryable<JobHistory> GetEntities()
        {
            return entityContext.JobHistories.AsQueryable();
        }
        protected override IQueryable<JobHistory> GetEntitiesWithoutTracking()
        {
            return entityContext.JobHistories.AsNoTracking().AsQueryable();
        }

        protected override JobHistory GetEntity(GovernmentDbContext entityContext, int id)
        {
            return entityContext.JobHistories.FirstOrDefault(e => e.PersonalID == id);
        }


    }
}
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMAHRAPI.Repository
{
    public class EduHistoryRepository : RepositoryBase<EduHistory>
    {
            public EduHistoryRepository()
            {
                this.entityContext = new GovernmentDbContext();
            }
            public EduHistoryRepository(GovernmentDbContext context)
            {
                this.entityContext = context;
            }
            protected override EduHistory AddEntity(GovernmentDbContext entityContext, EduHistory entity)
            {
                return entityContext.EduHistories.Add(entity);
            }

            protected override EduHistory AddOrUpdateEntity(GovernmentDbContext entityContext, EduHistory entity)
            {
                if (entity.PersonalID == default(int))
                {
                    return entityContext.EduHistories.Add(entity);
                }
                else
                {

                    return entityContext.EduHistories.FirstOrDefault(e => e.PersonalID == entity.PersonalID);
                }
            }

            protected override EduHistory UpdateEntity(GovernmentDbContext entityContext, EduHistory entity)
            {
                return entityContext.EduHistories.FirstOrDefault(e => e.PersonalID == entity.PersonalID);

            }

            protected override IQueryable<EduHistory> GetEntities()
            {
                return entityContext.EduHistories.AsQueryable();
            }
            protected override IQueryable<EduHistory> GetEntitiesWithoutTracking()
            {
                return entityContext.EduHistories.AsNoTracking().AsQueryable();
            }

            protected override EduHistory GetEntity(GovernmentDbContext entityContext, int id)
            {
                return entityContext.EduHistories.FirstOrDefault(e => e.PersonalID == id);
            }


        }
    }


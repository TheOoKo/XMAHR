using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMAHRAPI.Repository
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
       
        public GovernmentDbContext entityContext;
        protected abstract T AddEntity(GovernmentDbContext entityContext, T entity);
        protected abstract T AddOrUpdateEntity(GovernmentDbContext entityContext, T entity);
        protected abstract IQueryable<T> GetEntities();
        protected abstract IQueryable<T> GetEntitiesWithoutTracking();
        protected abstract T GetEntity(GovernmentDbContext entityContext, int id);
        protected abstract T UpdateEntity(GovernmentDbContext entityContext, T entity);


        public int Add(T entity)
        {
            int result = 0;
            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                var obj = AddEntity(entityContext, entity);
                result = entityContext.SaveChanges();

            }
            return result;
        }
        public T AddWithGetObj(T entity)
        {

            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                var obj = AddEntity(entityContext, entity);
                if (entityContext.SaveChanges() > 0)
                {
                    return obj;
                }
            }
            return null;
        }
        public int Remove(T entity)
        {
            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                return entityContext.SaveChanges();
            }
        }

        public int Remove(int id)
        {
            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                return entityContext.SaveChanges();
            }
        }

        public int Update(T entity)
        {
            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                entityContext.Entry<T>(entity).State = EntityState.Modified;
                return entityContext.SaveChanges();
            }
        }
        public T UpdatewithObj(T entity)
        {
            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                entityContext.Entry<T>(entity).State = EntityState.Modified;
                if (entityContext.SaveChanges() > 0)
                {
                    return entity;
                }
                return null;
            }
        }

        public IQueryable<T> Get()
        {
            return GetEntities();
        }
        public IQueryable<T> GetWithoutTracking()
        {
            return GetEntitiesWithoutTracking();
        }

        public T Get(int id)
        {
            using (GovernmentDbContext entityContext = new GovernmentDbContext())
            {
                return GetEntity(entityContext, id);
            }
        }


    }
}

using CRUDWITHUOWPT1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDWITHUOWPT1.Repository
{
    public class Repository<TEntity> : Repository.IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext context;
        private DbSet<TEntity> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return entities;
        }
        
        public TEntity GetById(int id)
        {
            return entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
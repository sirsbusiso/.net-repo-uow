using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWITHUOWPT1.Repository
{
    public interface IRepository<TEntity>
    where TEntity : class
    {
        void Delete(TEntity entity);
        System.Linq.IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
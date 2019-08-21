using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWITHUOWPT1.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository.IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
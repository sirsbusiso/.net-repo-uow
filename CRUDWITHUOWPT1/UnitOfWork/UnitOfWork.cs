using CRUDWITHUOWPT1.Models;
using CRUDWITHUOWPT1.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWITHUOWPT1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context = null;

        public UnitOfWork()
        {
            context = new ApplicationDbContext();
        }

        private Hashtable _repositories;

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

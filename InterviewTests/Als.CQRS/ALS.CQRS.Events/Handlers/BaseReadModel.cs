using System;
using System.Linq;
using ALS.CQRS.DataAccess.Interfaces;
using ALS.CQRS.DataAccess.ReadModels;
using JetBrains.Annotations;

namespace ALS.CQRS.Events.Handlers
{
    public abstract class BaseReadModel <T>
        : IDbContext <T>
        where T : DatabaseEntity
    {
        protected BaseReadModel(
            [NotNull] IDbSet <T> dbSet)
        {
            DbSet = dbSet;
        }

        private IDbSet <T> DbSet { get; }

        public virtual void Dispose()
        {
            DbSet.Dispose();
        }

        public IQueryable <T> All()
        {
            return DbSet;
        }

        public void Add(T instance)
        {
            DbSet.Add(instance);
        }

        public T Find(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(T instance)
        {
            DbSet.Remove(instance);
        }

        public void SaveChanges()
        {
            DbSet.SaveChanges();
        }

        public void Remove(Guid id)
        {
            T instance = DbSet.Find(id);

            DbSet.Remove(instance);
        }
    }
}
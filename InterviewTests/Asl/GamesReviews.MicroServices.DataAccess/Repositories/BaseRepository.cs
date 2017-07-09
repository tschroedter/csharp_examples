using System;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Contexts;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Repositories
{
    public abstract class BaseRepository <TType, TContext>
        : IRepository <TType>
        where TType : IEntity
        where TContext : IDbContext <TType>
    {
        protected BaseRepository([NotNull] TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public IQueryable <TType> All => GetAll();

        public TType FindById(Guid id)
        {
            return Context.Find(id);
        }

        public void Save(TType instance)
        {
            Context.Add(instance);
            Context.SaveChanges();
        }

        public void RemoveById(Guid id)
        {
            Context.Remove(id);
            Context.SaveChanges();
        }

        public void Remove(TType instance)
        {
            Context.Remove(instance.Id);
            Context.SaveChanges();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        protected abstract IQueryable <TType> GetAll();
    }
}
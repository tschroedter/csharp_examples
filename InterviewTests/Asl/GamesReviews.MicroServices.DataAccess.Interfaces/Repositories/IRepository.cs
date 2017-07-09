using System;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Repositories
{
    public interface IRepository <T>
        where T : IEntity
    {
        IQueryable <T> All { get; }
        T FindById(Guid id);
        void Save(T instance);
        void Remove(T entity);
        void RemoveById(Guid id);
    }
}
using System;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Contexts
{
    public interface IDbContext <T>
    {
        void Add(T instance);
        T Find(Guid id);
        void Remove(T instance);
        void SaveChanges();
        void Remove(Guid id);
    }
}
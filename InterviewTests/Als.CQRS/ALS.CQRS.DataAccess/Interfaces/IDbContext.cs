using System;
using System.Linq;
using ALS.CQRS.DataAccess.ReadModels;
using JetBrains.Annotations;

// ReSharper disable UnusedMember.Global

namespace ALS.CQRS.DataAccess.Interfaces
{
    public interface IDbContext <T>
        : IDisposable
        where T : DatabaseEntity
    {
        void Add([NotNull] T instance);
        IQueryable <T> All();
        T Find(Guid id);
        void Remove([NotNull] T instance);
        void Remove(Guid id);
        void SaveChanges();
    }
}
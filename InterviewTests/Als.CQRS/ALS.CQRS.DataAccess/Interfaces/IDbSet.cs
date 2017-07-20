using System;
using System.Linq;
using ALS.CQRS.DataAccess.ReadModels;
using JetBrains.Annotations;

namespace ALS.CQRS.DataAccess.Interfaces
{
    public interface IDbSet <T>
        : IQueryable <T>,
          IDisposable
        where T : DatabaseEntity
    {
        void Add([NotNull] T gameReview);
        T Find(Guid domainEventAggregateRootId);
        void Remove([NotNull] T instance);
        void SaveChanges();
    }
}
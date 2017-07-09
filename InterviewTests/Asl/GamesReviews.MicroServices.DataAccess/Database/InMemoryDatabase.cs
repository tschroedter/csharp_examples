using System;
using System.Collections.Concurrent;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Database;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Database
{
    [UsedImplicitly]
    public class InMemoryDatabase
        : IDatabase
    {
        private readonly ConcurrentDictionary <Guid, IGameReview> m_Dictionary =
            new ConcurrentDictionary <Guid, IGameReview>();

        public int GamesReviewsInDatabase => m_Dictionary.Count;

        public IQueryable <IGameReview> FindByRating(int rating)
        {
            return m_Dictionary.Values
                               .Where(x => x.Rating == rating)
                               .AsQueryable();
        }

        public void Add(IGameReview instance)
        {
            if ( instance.Id == default( Guid ) )
            {
                instance.Id = Guid.NewGuid();
            }

            m_Dictionary [ instance.Id ] = instance;
        }

        public IGameReview Find(Guid id)
        {
            IGameReview review;

            return m_Dictionary.TryGetValue(id,
                                            out review)
                       ? review
                       : new GameReview();
        }

        public void Remove(IGameReview instance)
        {
            Remove(instance.Id);
        }

        public void SaveChanges()
        {
            // nothing todo here
        }

        public IQueryable <IGameReview> GamesReviews()
        {
            return m_Dictionary.Values.ToArray().AsQueryable();
        }

        public void Remove(Guid id)
        {
            IGameReview removed;

            m_Dictionary.TryRemove(id,
                                   out removed);
        }
    }
}
using System;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Contexts;
using GamesReviews.MicroServices.DataAccess.Interfaces.Database;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Contexts
{
    public class GamesReviewsContext
        : IGamesReviewsContext
    {
        private readonly IDatabase m_Database;

        public GamesReviewsContext(
            [NotNull] IDatabase database)
        {
            m_Database = database;
        }

        public void Add(IGameReview instance)
        {
            m_Database.Add(instance);
        }

        public IGameReview Find(Guid id)
        {
            return m_Database.Find(id);
        }

        public void Remove(IGameReview instance)
        {
            m_Database.Remove(instance);
        }

        public void Remove(Guid id)
        {
            m_Database.Remove(id);
        }

        public void SaveChanges()
        {
            m_Database.SaveChanges();
        }

        public IQueryable <IGameReview> GamesReviews()
        {
            return m_Database.GamesReviews();
        }

        public IQueryable <IGameReview> FindByRating(int rating)
        {
            return m_Database.FindByRating(rating);
        }
    }
}
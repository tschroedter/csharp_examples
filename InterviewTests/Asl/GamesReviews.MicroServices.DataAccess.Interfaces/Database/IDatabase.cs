using System;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Database
{
    public interface IDatabase
    {
        int GamesReviewsInDatabase { get; }
        void Add(IGameReview instance);
        IGameReview Find(Guid id);
        void Remove(IGameReview instance);
        void SaveChanges();
        IQueryable <IGameReview> GamesReviews();
        void Remove(Guid id);
        IQueryable <IGameReview> FindByRating(int rating);
    }
}
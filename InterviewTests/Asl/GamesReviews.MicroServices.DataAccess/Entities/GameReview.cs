using System.Diagnostics.CodeAnalysis;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;

namespace GamesReviews.MicroServices.DataAccess.Entities
{
    [ExcludeFromCodeCoverage]
    public class GameReview
        : Entity,
          IGameReview
    {
        public string Title { get; set; } // The title of the game
        public string Description { get; set; } // Description of the game
        public int Rating { get; set; } // Rating The average rating based on votes from users (from 1-5 stars).
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ALS.CQRS.DataAccess.ReadModels
{
    [UsedImplicitly]
    [Table("GameReviews")]
    public class GameReview
        : DatabaseEntity
    {
        public Guid GameReviewId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
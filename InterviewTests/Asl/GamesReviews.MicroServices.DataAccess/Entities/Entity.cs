using System;
using System.Diagnostics.CodeAnalysis;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;

namespace GamesReviews.MicroServices.DataAccess.Entities
{
    [ExcludeFromCodeCoverage]
    public class Entity
        : IEntity
    {
        public Guid Id { get; set; }
    }
}
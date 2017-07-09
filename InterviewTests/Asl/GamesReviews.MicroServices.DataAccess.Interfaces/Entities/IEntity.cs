using System;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using GamesReviews.MicroServices.Nancy.Interfaces;

namespace GamesReviews.MicroServices.Nancy
{
    [ExcludeFromCodeCoverage]
    public class Model
        : IModel
    {
        public Guid Id { get; set; }
    }
}
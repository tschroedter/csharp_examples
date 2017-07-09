using System.Diagnostics.CodeAnalysis;
using Autofac;
using GamesReviews.MicroServices.DataAccess.Contexts;
using GamesReviews.MicroServices.DataAccess.Database;
using GamesReviews.MicroServices.DataAccess.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Repositories;
using GamesReviews.MicroServices.DataAccess.Repositories;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class DataAccessAutoFacModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType <GamesReviewsContext>()
                   .AsImplementedInterfaces();
            builder.RegisterType <InMemoryDatabase>()
                   .AsImplementedInterfaces()
                   .SingleInstance();
            builder.RegisterType <GameReview>()
                   .AsImplementedInterfaces();
            builder.RegisterType <GamesReviewsRepository>()
                   .As <IGamesReviewsRepository>();
            builder.RegisterType <GamesReviewsRepository>()
                   .As <ICommandGamesReviewsRepository>();
            builder.RegisterType <GamesReviewsRepository>()
                   .As <IQueryGamesReviewsRepository>();
        }
    }
}
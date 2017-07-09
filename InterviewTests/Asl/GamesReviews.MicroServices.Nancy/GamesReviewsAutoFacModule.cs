using System.Diagnostics.CodeAnalysis;
using Autofac;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.Nancy
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class GamesReviewsAutoFacModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType <Model>()
                   .AsImplementedInterfaces();
            builder.RegisterType <GameReviewModel>()
                   .AsImplementedInterfaces();
            builder.RegisterType <InformationFinder>()
                   .AsImplementedInterfaces();
            builder.RegisterType <RequestHandler>()
                   .AsImplementedInterfaces();
        }
    }
}
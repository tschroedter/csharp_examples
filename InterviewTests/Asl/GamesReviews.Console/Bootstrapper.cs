using System.Diagnostics.CodeAnalysis;
using Autofac;
using GamesReviews.MicroServices.DataAccess;
using GamesReviews.MicroServices.Nancy;
using JetBrains.Annotations;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace GamesReviews.Console
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class Bootstrapper
        : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(
            ILifetimeScope container)
        {
            container.Update(builder =>
                             {
                                 builder.RegisterModule <DataAccessAutoFacModule>();
                                 builder.RegisterModule <GamesReviewsAutoFacModule>();

                                 builder.RegisterType <PopulateDatabase>()
                                        .AsImplementedInterfaces();
                             });
        }

        protected override void ApplicationStartup(ILifetimeScope container,
                                                   IPipelines pipelines)
        {
            base.ApplicationStartup(container,
                                    pipelines);

            var populate = container.Resolve <IPopulateDatabase>();
            populate.Populate();
        }
    }
}
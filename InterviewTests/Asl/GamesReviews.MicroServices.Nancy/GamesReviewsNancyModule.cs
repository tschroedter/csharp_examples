using System;
using System.Diagnostics.CodeAnalysis;
using GamesReviews.MicroServices.Nancy.Interfaces;
using JetBrains.Annotations;
using Nancy;
using Nancy.ModelBinding;

namespace GamesReviews.MicroServices.Nancy
{
    [ExcludeFromCodeCoverage]
    public sealed class GamesReviewsNancyModule
        : NancyModule
    {
        public GamesReviewsNancyModule(
            [NotNull] IRequestHandler handler)
            : base("/gamereview")
        {
            // todo async
            Get [ "/" ] = ListFunc(handler);
            Get [ "/{id:guid}" ] = FindByIdFunc(handler);
            Get [ "/byrating/{rating:int}" ] = FindByFuncRating(handler);
            Post [ "/" ] = SaveFunc(handler);
            Put [ "/" ] = SaveFunc(handler);
            Delete [ "/{id:guid}" ] = DeleteFunc(handler);
        }

        private static Func <dynamic, dynamic> DeleteFunc(IRequestHandler handler)
        {
            return parameters => handler.Delete(( Guid ) parameters.id);
        }

        private Func <dynamic, dynamic> SaveFunc(IRequestHandler handler)
        {
            return parameters => handler.Save(this.Bind <GameReviewModel>());
        }

        private static Func <dynamic, dynamic> FindByFuncRating(IRequestHandler handler)
        {
            return parameters => handler.FindByRating(( int ) parameters.rating);
        }

        private static Func <dynamic, dynamic> FindByIdFunc(IRequestHandler handler)
        {
            return parameters => handler.FindById(( Guid ) parameters.id);
        }

        private static Func <dynamic, dynamic> ListFunc(IRequestHandler handler)
        {
            return parameters => handler.List();
        }
    }
}
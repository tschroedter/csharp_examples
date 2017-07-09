using System;
using System.Collections.Generic;
using GamesReviews.MicroServices.Nancy.Interfaces;
using JetBrains.Annotations;
using Nancy;
using Newtonsoft.Json;

namespace GamesReviews.MicroServices.Nancy
{
    [UsedImplicitly]
    public class RequestHandler
        : IRequestHandler
    {
        private readonly IInformationFinder m_InformationFinder;

        public RequestHandler([NotNull] IInformationFinder informationFinder)
        {
            m_InformationFinder = informationFinder;
        }

        public Response List()
        {
            IEnumerable <IGameReviewModel> models = m_InformationFinder.List();

            return AsJson(models);
        }

        public Response FindById(Guid id)
        {
            IGameReviewModel model = m_InformationFinder.FindById(id);

            return model == null
                       ? HttpStatusCode.NotFound
                       : AsJson(model);
        }

        public Response Save(IGameReviewModel instance)
        {
            m_InformationFinder.Save(instance);

            return AsJson(instance);
        }

        public Response Delete(Guid id)
        {
            m_InformationFinder.Delete(id);

            return AsJson(id);
        }

        public Response FindByRating(int rating)
        {
            IEnumerable <IGameReviewModel> models = m_InformationFinder.FindByRating(rating);

            return models == null
                       ? HttpStatusCode.NotFound
                       : AsJson(models);
        }

        private Response AsJson(object instance) // todo testing
        {
            Response response = JsonConvert.SerializeObject(instance);

            response.ContentType = "application/json";

            return response;
        }
    }
}
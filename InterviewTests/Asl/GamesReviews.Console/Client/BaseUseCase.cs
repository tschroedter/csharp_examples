using System.Collections.Generic;
using System.Text;
using GamesReviews.MicroServices.Nancy;
using GamesReviews.MicroServices.Nancy.Interfaces;
using JetBrains.Annotations;
using RestSharp;

namespace GamesReviews.Console.Client
{
    public class BaseUseCase
    {
        public BaseUseCase()
        {
            Client = new RestClient("http://localhost:63579/");
        }

        protected IRestClient Client { get; }


        public List <GameReviewModel> GetAllReviews()
        {
            var request = new RestRequest("gamereview",
                                          Method.GET);

            IRestResponse <List <GameReviewModel>> responseAll = Client.Execute <List <GameReviewModel>>(request);

            return responseAll.Data;
        }

        public string ToStringModels(
            [NotNull] IEnumerable <GameReviewModel> models)
        {
            var builder = new StringBuilder();

            foreach ( GameReviewModel model in models )
            {
                string toString = ToStringModel(model);

                builder.Append(toString);
            }

            return builder.ToString();
        }

        public string ToStringModel([NotNull] IGameReviewModel model)
        {
            var builder = new StringBuilder();

            builder.AppendLine("Title: " + model.Title);
            builder.AppendLine("Description: " + model.Description);
            builder.AppendLine("Rating: " + model.Rating);
            builder.AppendLine("RatingAsStars: " + model.RatingAsStars);

            return builder.ToString();
        }
    }
}
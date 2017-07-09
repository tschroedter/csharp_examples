using System;
using System.Collections.Generic;
using System.Linq;
using GamesReviews.MicroServices.Nancy;
using JetBrains.Annotations;
using RestSharp;

namespace GamesReviews.Console.Client
{
    public class UseCaseOne
        : BaseUseCase
    {
        public void Run()
        {
            System.Console.WriteLine("1. As a gamer I want to edit the descriptions " +
                                     "so that everyone can see the latest game information.\n");

            List <GameReviewModel> allReviews = GetAllReviews();

            System.Console.WriteLine("Current Reviews:");
            System.Console.WriteLine(ToStringModels(allReviews));
            System.Console.WriteLine();

            System.Console.WriteLine("Updating review...");
            GameReviewModel updateReview = UpdateReview(allReviews.First());

            GameReviewModel updated = GetReviewById(updateReview.Id);

            System.Console.WriteLine("...updated review:");
            System.Console.WriteLine(ToStringModel(updated));
        }

        private GameReviewModel UpdateReview(
            [NotNull] GameReviewModel review)
        {
            review.Description = "New Description";

            var request = new RestRequest("gamereview/",
                                          Method.PUT);

            request.AddJsonBody(review);
            Client.Execute(request);

            return review;
        }

        private GameReviewModel GetReviewById(Guid id)
        {
            var request = new RestRequest("gamereview/{id}",
                                          Method.GET);

            request.AddUrlSegment("id",
                                  id.ToString());

            IRestResponse <GameReviewModel> responseAll = Client.Execute <GameReviewModel>(request);

            return responseAll.Data;
        }
    }
}
using System.Collections.Generic;
using GamesReviews.MicroServices.Nancy;
using RestSharp;

namespace GamesReviews.Console.Client
{
    public class UseCaseThree
        : BaseUseCase
    {
        public void Run()
        {
            System.Console.WriteLine("\n3. As a gamer I want to view games based on rating " +
                                     "so that I can find the most popular ones.\n");

            List <GameReviewModel> allReviews = GetAllReviewsByRating(3);

            System.Console.WriteLine("Review by Rating:");
            System.Console.WriteLine(ToStringModels(allReviews));
            System.Console.WriteLine();
        }

        private List <GameReviewModel> GetAllReviewsByRating(
            int rating)
        {
            var request = new RestRequest("gamereview/byrating/{rating}",
                                          Method.GET);

            request.AddUrlSegment("rating",
                                  rating.ToString());

            IRestResponse <List <GameReviewModel>> responseAll = Client.Execute <List <GameReviewModel>>(request);

            return responseAll.Data;
        }
    }
}
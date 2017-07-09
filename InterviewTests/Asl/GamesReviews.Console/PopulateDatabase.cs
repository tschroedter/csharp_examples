using System;
using System.Diagnostics.CodeAnalysis;
using GamesReviews.MicroServices.DataAccess.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;

namespace GamesReviews.Console
{
    [ExcludeFromCodeCoverage]
    public class PopulateDatabase
        : IPopulateDatabase
    {
        private readonly ICommandGamesReviewsRepository m_Command;

        public PopulateDatabase(
            [NotNull] ICommandGamesReviewsRepository command)
        {
            m_Command = command;
        }

        public void Populate()
        {
            var one = new GameReview
                      {
                          Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                          Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                          Title = "Gears of War 3",
                          Rating = 5
                      };

            var two = new GameReview
                      {
                          Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                          Description = "Integer magna magna, iaculis euismod tincidunt a, cursus ac dolor. " +
                                        "Aenean quis egestas diam.Pellentesque purus ipsum, elementum sit amet " +
                                        "malesuada eget, aliquet eu magna.Nullam magna massa, sodales nec " +
                                        "imperdiet quis, consectetur eget nisl.Aenean eget velit in eros porta " +
                                        "dictum.Sed eu dui in augu",
                          Title = "Step Up for Kinnect",
                          Rating = 1
                      };

            var three = new GameReview
                        {
                            Id = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                            Description = "Vivamus purus eros, aliquet malesuada gravida at, fringilla vel elit. " +
                                          "Mauris vestibulum, erat at volutpat semper, metus enim faucibus nunc, " +
                                          "in ultrices magna enim in justo",
                            Title = "Dead Island",
                            Rating = 3
                        };

            m_Command.Save(one);
            m_Command.Save(two);
            m_Command.Save(three);
        }
    }

    public interface IPopulateDatabase
    {
        void Populate();
    }
}
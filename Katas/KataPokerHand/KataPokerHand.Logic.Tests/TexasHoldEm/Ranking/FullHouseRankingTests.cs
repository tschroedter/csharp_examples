using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using static System.Console;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FullHouseRankingTests
    {
        [SetUp]
        public void Setup()
        {
            m_InfoOne = Substitute.For <IPlayerHandInformation>();
            m_InfoTwo = Substitute.For <IPlayerHandInformation>();
            m_Infos = new[]
                      {
                          m_InfoOne,
                          m_InfoTwo
                      };

            m_Sut = new FullHouseRanking();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private FullHouseRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;

        [TestCase(Status.Unknown,
            false)]
        [TestCase(Status.NumberOfCardsIncorrect,
            false)]
        [TestCase(Status.StraightFlush,
            false)]
        [TestCase(Status.FourOfAKind,
            false)]
        [TestCase(Status.FullHouse,
            true)]
        [TestCase(Status.Flush,
            false)]
        [TestCase(Status.Straight,
            false)]
        [TestCase(Status.ThreeOfAKind,
            false)]
        [TestCase(Status.TwoPairs,
            false)]
        [TestCase(Status.OnePair,
            false)]
        [TestCase(Status.HighCard,
            false)]
        public void CanApply_Returns_Expected(
            Status status,
            bool expected)
        {
            // Arrange
            WriteLine("Testing: " + status);

            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.CanApply(status));
        }

        private IEnumerable <ICard> CreateThreeOfAKindOfTwos()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts()
                   };
        }

        private IEnumerable <ICard> CreateThreeOfAKindOfThrees()
        {
            return new ICard[]
                   {
                       new ThreeOfClubs(),
                       new ThreeOfDiamonds(),
                       new ThreeOfHearts()
                   };
        }

        [Test]
        public void Apply_Updates_Winner_For_Single_Winner_For_Twos_And_Threes()
        {
            // Arrange
            m_InfoOne.ThreeOfAKind = CreateThreeOfAKindOfTwos();
            m_InfoTwo.ThreeOfAKind = CreateThreeOfAKindOfThrees();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
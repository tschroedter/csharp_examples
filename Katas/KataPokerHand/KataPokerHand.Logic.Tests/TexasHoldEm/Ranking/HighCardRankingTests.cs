using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class HighCardRankingTests
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
            m_Rank = new RankByCardIndex(); // todo use NSub...

            m_Sut = new HighCardRanking(m_Rank);
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private HighCardRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;
        private IRankByCardIndex m_Rank;

        [TestCase(Status.Unknown,
            false)]
        [TestCase(Status.NumberOfCardsIncorrect,
            false)]
        [TestCase(Status.StraightFlush,
            false)]
        [TestCase(Status.FourOfAKind,
            false)]
        [TestCase(Status.FullHouse,
            false)]
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
            true)]
        public void CanApply_Returns_Expected(
            Status status,
            bool expected)
        {
            // Arrange
            Console.WriteLine("Testing: " + status);

            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.CanApply(status));
        }

        [Test]
        public void Apply_Updates_Ranked_For_All_Cards_Same()
        {
            // Arrange
            m_InfoOne.Cards = new ICard[]
                              {
                                  new NineOfClubs()
                              };

            m_InfoTwo.Cards = new ICard[]
                              {
                                  new NineOfHearts()
                              };

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].Cards.First() is NineOfClubs);
            Assert.True(actual [ 1 ].Cards.First() is NineOfHearts);
            Assert.AreEqual(WinnerStatus.MultipleWinners,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Ranked_Sorted_By_HighestCard_First_Card()
        {
            // Arrange
            m_InfoOne.Cards = new ICard[]
                              {
                                  new NineOfClubs()
                              };

            m_InfoTwo.Cards = new ICard[]
                              {
                                  new AceOfHearts()
                              };

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].Cards.First() is AceOfHearts);
            Assert.True(actual [ 1 ].Cards.First() is NineOfClubs);
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Ranked_Sorted_By_HighestCard_Second_Card()
        {
            // Arrange
            m_InfoOne.Cards = new ICard[]
                              {
                                  new NineOfClubs(),
                                  new JackOfClubs()
                              };

            m_InfoTwo.Cards = new ICard[]
                              {
                                  new NineOfHearts(),
                                  new AceOfHearts()
                              };

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].Cards.ElementAt(0) is NineOfHearts);
            Assert.True(actual [ 0 ].Cards.ElementAt(1) is AceOfHearts);
            Assert.True(actual [ 1 ].Cards.ElementAt(0) is NineOfClubs);
            Assert.True(actual [ 1 ].Cards.ElementAt(1) is JackOfClubs);
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
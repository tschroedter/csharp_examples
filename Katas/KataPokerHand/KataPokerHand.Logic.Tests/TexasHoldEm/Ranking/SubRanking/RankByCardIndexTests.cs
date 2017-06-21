using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking.SubRanking;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking.SubRanking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class RankByCardIndexTests
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

            m_Sut = new RankByCardIndex();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private RankByCardIndex m_Sut;
        private IPlayerHandInformation[] m_Infos;

        [TestCase(0,
            false)]
        [TestCase(1,
            true)]
        public void HasSingleWinnerAtCardIndex_Returns_False_For_All_Same(
            int index,
            bool expected)
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
                                  new QueenOfHearts()
                              };

            // Act
            bool actual = m_Sut.HasSingleWinnerAtCardIndex(index,
                                                           m_Infos);

            // Assert
            Assert.AreEqual(expected,
                            actual);
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
            IPlayerHandInformation[] actual = m_Sut.RankedByCardIndex(1,
                                                                      m_Infos).ToArray();

            // Assert
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].Cards.ElementAt(0) is NineOfHearts);
            Assert.True(actual [ 0 ].Cards.ElementAt(1) is AceOfHearts);
            Assert.True(actual [ 1 ].Cards.ElementAt(0) is NineOfClubs);
            Assert.True(actual [ 1 ].Cards.ElementAt(1) is JackOfClubs);
        }

        [Test]
        public void RankedByCardIndex_Returns_Ranked_For_All_Cards_Same()
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
            IPlayerHandInformation[] actual = m_Sut.RankedByCardIndex(0,
                                                                      m_Infos).ToArray();

            // Assert
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].Cards.First() is NineOfClubs);
            Assert.True(actual [ 1 ].Cards.First() is NineOfHearts);
        }

        [Test]
        public void RankedByCardIndex_Returns_Ranked_Sorted_By_HighestCard_First_Card()
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
            IPlayerHandInformation[] actual = m_Sut.RankedByCardIndex(0,
                                                                      m_Infos).ToArray();

            // Assert
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].Cards.First() is AceOfHearts);
            Assert.True(actual [ 1 ].Cards.First() is NineOfClubs);
        }
    }
}
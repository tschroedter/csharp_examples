using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeOfAKindRankingTests
    {
        [SetUp]
        public void Setup()
        {
            m_InfoOne = Substitute.For<IPlayerHandInformation>();
            m_InfoTwo = Substitute.For<IPlayerHandInformation>();
            m_Infos = new[]
                      {
                          m_InfoOne,
                          m_InfoTwo
                      };

            m_Sut = new ThreeOfAKindRanking();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private ThreeOfAKindRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;

        private IEnumerable<ICard> CreateThreeOfAKindOfTwos()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts()
                   };
        }

        private IEnumerable<ICard> CreateThreeOfAKindOfThrees()
        {
            return new ICard[]
                   {
                       new ThreeOfClubs(),
                       new ThreeOfDiamonds(),
                       new ThreeOfHearts()
                   };
        }

        [Test]
        public void Apply_Updates_Ranked_For_Twos_And_Threes()
        {
            // Arrange
            m_InfoOne.ThreeOfAKind = CreateThreeOfAKindOfTwos();
            m_InfoTwo.ThreeOfAKind = CreateThreeOfAKindOfThrees();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Count());
            Assert.AreEqual(m_InfoTwo,
                            actual[0]);
            Assert.AreEqual(m_InfoOne,
                            actual[1]);
        }

        [Test]
        public void Apply_Updates_Winner_For_Same()
        {
            // Arrange
            m_InfoOne.ThreeOfAKind = CreateThreeOfAKindOfTwos();
            m_InfoTwo.ThreeOfAKind = CreateThreeOfAKindOfTwos();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.MultipleWinners,
                            m_Sut.Winner);
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
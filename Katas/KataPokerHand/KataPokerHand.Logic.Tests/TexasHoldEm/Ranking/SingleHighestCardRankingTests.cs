using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SingleHighestCardRankingTests
    {
        private class TestSingleHighestCardRanking
            : SingleHighestCardRanking
        {
            public TestSingleHighestCardRanking()
                : base(Status.StraightFlush)
            {
            }
        }

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

            m_Sut = new TestSingleHighestCardRanking();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private TestSingleHighestCardRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;

        [Test]
        public void Apply_Updates_Ranked_Not_Sorted_For_All_Same_HighestCard()
        {
            // Arrange
            m_InfoOne.HighestCard = new NineOfClubs();
            m_InfoTwo.HighestCard = new NineOfHearts();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].HighestCard is NineOfClubs);
            Assert.True(actual [ 1 ].HighestCard is NineOfHearts);
        }

        [Test]
        public void Apply_Updates_Ranked_Sorted_By_HighestCard()
        {
            // Arrange
            m_InfoOne.HighestCard = new NineOfClubs();
            m_InfoTwo.HighestCard = new AceOfHearts();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ].HighestCard is AceOfHearts);
            Assert.True(actual [ 1 ].HighestCard is NineOfClubs);
        }

        [Test]
        public void Apply_Updates_Winner_For_All_Different_HighestCard()
        {
            // Arrange
            m_InfoOne.HighestCard = new NineOfClubs();
            m_InfoTwo.HighestCard = new AceOfHearts();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Winner_For_All_Same_HighestCard()
        {
            // Arrange
            m_InfoOne.HighestCard = new NineOfClubs();
            m_InfoTwo.HighestCard = new NineOfHearts();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(WinnerStatus.MultipleWinners,
                            m_Sut.Winner);
        }
    }
}
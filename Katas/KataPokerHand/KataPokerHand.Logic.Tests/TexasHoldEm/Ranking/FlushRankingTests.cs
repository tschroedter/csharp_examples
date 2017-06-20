using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FlushRankingTests
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

            m_Sut = new FlushRanking();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private FlushRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;

        [Test]
        public void Apply_Updates_Ranked_For_Twos_And_Threes()
        {
            // Arrange
            m_InfoOne.HighestCard = new TwoOfClubs();
            m_InfoTwo.HighestCard = new ThreeOfClubs();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Count());
            Assert.AreEqual(m_InfoTwo,
                            actual [ 0 ]);
            Assert.AreEqual(m_InfoOne,
                            actual [ 1 ]);
        }

        [Test]
        public void Apply_Updates_Winner_To_Single_For_Two_And_Three()
        {
            // Arrange
            m_InfoOne.HighestCard = new TwoOfClubs();
            m_InfoTwo.HighestCard = new ThreeOfClubs();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Winner_To_MultipleWinners_For_Two_And_Two()
        {
            // Arrange
            m_InfoOne.HighestCard = new TwoOfClubs();
            m_InfoTwo.HighestCard = new TwoOfClubs();

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.MultipleWinners,
                            m_Sut.Winner);
        }
    }
}
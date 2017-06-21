using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoPairsRankingTests
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

            m_First = Substitute.For <IFirstPairRanking>();
            m_Second = Substitute.For <ISecondPairRanking>();
            m_HighCard = Substitute.For <IHighCardRanking>();

            m_Sut = new TwoPairsRanking(m_First,
                                        m_Second,
                                        m_HighCard);
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private TwoPairsRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;
        private IFirstPairRanking m_First;
        private ISecondPairRanking m_Second;
        private IHighCardRanking m_HighCard;

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner_FirstPair()
        {
            // Arrange
            m_First.Winner.Returns(WinnerStatus.SingleWinner);
            m_First.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(m_Infos,
                            m_Sut.Ranked);
        }

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner_HighCard()
        {
            // Arrange
            m_First.Winner.Returns(WinnerStatus.Unknown);
            m_Second.Winner.Returns(WinnerStatus.Unknown);
            m_HighCard.Winner.Returns(WinnerStatus.SingleWinner);
            m_HighCard.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(m_Infos,
                            m_Sut.Ranked);
        }

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner_SecondtPair()
        {
            // Arrange
            m_First.Winner.Returns(WinnerStatus.Unknown);
            m_Second.Winner.Returns(WinnerStatus.SingleWinner);
            m_Second.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(m_Infos,
                            m_Sut.Ranked);
        }

        [Test]
        public void Apply_Updates_Winner_For_Single_Winner_FirstPair()
        {
            // Arrange
            m_First.Winner.Returns(WinnerStatus.SingleWinner);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Winner_For_Single_Winner_HighCard()
        {
            // Arrange
            m_First.Winner.Returns(WinnerStatus.Unknown);
            m_Second.Winner.Returns(WinnerStatus.Unknown);
            m_HighCard.Winner.Returns(WinnerStatus.SingleWinner);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Winner_For_Single_Winner_SecondPair()
        {
            // Arrange
            m_First.Winner.Returns(WinnerStatus.Unknown);
            m_Second.Winner.Returns(WinnerStatus.SingleWinner);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;

namespace KataPokerHand.Logic.TexasHoldEm
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class CardsRankingTests
    {
        [SetUp]
        public void Setup()
        {
            m_StatusList = new[]
                           {
                               Status.StraightFlush
                           };
            m_InfoOne = Substitute.For <IPlayerHandInformation>();
            m_InfoTwo = Substitute.For <IPlayerHandInformation>();
            m_Infos = new[]
                      {
                          m_InfoOne,
                          m_InfoTwo
                      };

            m_Grouped = Substitute.For <IPlayerInformationGroupedByStatus>();
            m_Container = Substitute.For <ISameStatusRankingContainer>();

            m_Sut = new CardsRanking(m_Grouped,
                                     m_Container);
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private IPlayerHandInformation[] m_Infos;
        private CardsRanking m_Sut;
        private IPlayerInformationGroupedByStatus m_Grouped;
        private ISameStatusRankingContainer m_Container;
        private Status[] m_StatusList;

        [Test]
        public void Apply_Updates_Winner_For_No_Single_Winner()
        {
            // Arrange
            m_Grouped.Keys.Returns(m_StatusList);
            m_Container.Winner.Returns(WinnerStatus.MultipleWinners);
            m_Container.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.Unknown,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Winner_For_Single_Winner()
        {
            // Arrange
            m_Grouped.Keys.Returns(m_StatusList);
            m_Container.Winner.Returns(WinnerStatus.SingleWinner);
            m_Container.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_WinnerInformation_For_No_Single_Winner()
        {
            // Arrange
            m_Grouped.Keys.Returns(m_StatusList);
            m_Container.Winner.Returns(WinnerStatus.MultipleWinners);
            m_Container.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(Status.Unknown,
                            m_Sut.WinnerInformation.Status);
        }

        [Test]
        public void Apply_Updates_WinnerInformation_For_Single_Winner()
        {
            // Arrange
            m_Grouped.Keys.Returns(m_StatusList);
            m_Container.Winner.Returns(WinnerStatus.SingleWinner);
            m_Container.Ranked.Returns(m_Infos);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(m_InfoOne,
                            m_Sut.WinnerInformation);
        }

        [Test]
        public void Winner_Returns_Default()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(WinnerStatus.Unknown,
                            m_Sut.Winner);
        }

        [Test]
        public void WinnerInformation_Returns_Default()
        {
            // Arrange
            // Act
            // Assert
            Assert.NotNull(m_Sut.WinnerInformation);
        }
    }
}
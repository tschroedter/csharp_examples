using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StraightRankingTests
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

            m_Ranking = Substitute.For <IHighCardRanking>();

            m_Sut = new StraightRanking(m_Ranking);
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private StraightRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;
        private IHighCardRanking m_Ranking;

        [Test]
        public void Apply_Updates_Ranked()
        {
            // Arrange
            var result = Substitute.For <IPlayerHandInformation>();
            var ranked = new[]
                         {
                             result
                         };
            m_Ranking.Ranked.Returns(ranked);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(1,
                            actual.Count());
            Assert.AreEqual(result,
                            actual [ 0 ]);
        }

        [Test]
        public void Apply_Updates_Ranked_Clears_Ranked()
        {
            // Arrange
            var result = Substitute.For <IPlayerHandInformation>();
            var ranked = new[]
                         {
                             result
                         };
            m_Ranking.Ranked.Returns(ranked);
            m_Sut.Apply(m_Infos);

            m_Ranking.Ranked.Returns(new IPlayerHandInformation[0]);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(0,
                            m_Sut.Ranked.Count());
        }

        [Test]
        public void Apply_Updates_Winner()
        {
            // Arrange
            var result = Substitute.For <IPlayerHandInformation>();
            var ranked = new[]
                         {
                             result
                         };
            m_Ranking.Ranked.Returns(ranked);
            m_Ranking.Winner.Returns(WinnerStatus.SingleWinner);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
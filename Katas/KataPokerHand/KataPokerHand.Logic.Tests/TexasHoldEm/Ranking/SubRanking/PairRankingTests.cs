using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking.SubRanking;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking.SubRanking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PairRankingTests
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

            m_Sut = new PairRanking();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private PairRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;

        private void Create2C2D([NotNull] IPlayerHandInformation info)
        {
            info.PairOfCards = new ICard[]
                               {
                                   new TwoOfClubs(),
                                   new TwoOfDiamonds()
                               };
        }

        private void Create6C6D([NotNull] IPlayerHandInformation info)
        {
            info.PairOfCards = new ICard[]
                               {
                                   new SixOfClubs(),
                                   new SixOfDiamonds()
                               };
        }

        [Test]
        public void Apply_Updates_Ranked_For_Multiple_Winners()
        {
            // Arrange
            Create2C2D(m_InfoOne);
            Create2C2D(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Count());
            Assert.AreEqual(m_InfoOne,
                            actual [ 0 ]);
            Assert.AreEqual(m_InfoTwo,
                            actual [ 1 ]);
        }

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner()
        {
            // Arrange
            Create2C2D(m_InfoOne);
            Create6C6D(m_InfoTwo);

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
        public void Apply_Updates_Winner_For_Multiple_Winners()
        {
            // Arrange
            Create2C2D(m_InfoOne);
            Create2C2D(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.MultipleWinners,
                            m_Sut.Winner);
        }


        [Test]
        public void Apply_Updates_Winner_For_Single_Winner()
        {
            // Arrange
            Create2C2D(m_InfoOne);
            Create6C6D(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FirstPairRankingTests
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

            m_Sut = new FirstPairRanking();
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private FirstPairRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;

        private void Create2C2D3C3D4C([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new TwoOfClubs(),
                                        new TwoOfDiamonds()
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new ThreeOfClubs(),
                                         new ThreeOfDiamonds()
                                     };

            info.HighestCard = new FourOfClubs();
        }

        private void Create2S2H4S4H5S([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new TwoOfSpades(),
                                        new TwoOfHearts(),
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new FourOfSpades(),
                                         new FourOfHearts()
                                     };

            info.HighestCard = new FiveOfSpades();
        }

        private void Create3S3H4S4H5S([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new ThreeOfSpades(),
                                        new ThreeOfHearts(),
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new FourOfSpades(),
                                         new FourOfHearts()
                                     };

            info.HighestCard = new FiveOfSpades();
        }

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create3S3H4S4H5S(m_InfoTwo);

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
        public void Apply_Updates_Ranked_For_Multiple_Winners()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2C2D3C3D4C(m_InfoTwo);

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
        public void Apply_Updates_Winner_For_Multiple_Winners()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2C2D3C3D4C(m_InfoTwo);

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
            Create2C2D3C3D4C(m_InfoOne);
            Create3S3H4S4H5S(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
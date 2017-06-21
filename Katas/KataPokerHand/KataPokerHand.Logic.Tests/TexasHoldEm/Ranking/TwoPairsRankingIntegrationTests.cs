using System.Collections.Generic;
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
    internal sealed class TwoPairsRankingIntegrationTests
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

            m_First = new FirstPairRanking();
            m_Second = new SecondPairRanking();
            m_HighCard = new HighCardRanking(new RankByCardIndex());

            m_Sut = new TwoPairsRanking(m_First,
                                        m_Second,
                                        m_HighCard);
        }

        private IPlayerHandInformation m_InfoOne;
        private IPlayerHandInformation m_InfoTwo;
        private TwoPairsRanking m_Sut;
        private IPlayerHandInformation[] m_Infos;
        private FirstPairRanking m_First;
        private SecondPairRanking m_Second;
        private HighCardRanking m_HighCard;

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

            UpdateCards(info);
        }

        private static void UpdateCards(IPlayerHandInformation info)
        {
            var cards = new List<ICard>();
            cards.AddRange(info.FirstPairOfCards);
            cards.AddRange(info.SecondPairOfCards);
            cards.Add(info.HighestCard);
            info.Cards = cards;
        }

        private void Create2H2S3H3S5C([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new TwoOfHearts(),
                                        new TwoOfSpades()
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new ThreeOfHearts(),
                                         new ThreeOfSpades()
                                     };

            info.HighestCard = new FiveOfClubs();

            UpdateCards(info);
        }

        private void Create2H2S3H3S4H([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new TwoOfHearts(),
                                        new TwoOfSpades()
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new ThreeOfHearts(),
                                         new ThreeOfSpades()
                                     };

            info.HighestCard = new FourOfHearts();

            UpdateCards(info);
        }

        private void Create2S2H4S4H5S([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new TwoOfSpades(),
                                        new TwoOfHearts()
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new FourOfSpades(),
                                         new FourOfHearts()
                                     };

            info.HighestCard = new FiveOfSpades();


            UpdateCards(info);
        }

        private void Create3S3H4S4H5S([NotNull] IPlayerHandInformation info)
        {
            info.FirstPairOfCards = new ICard[]
                                    {
                                        new ThreeOfSpades(),
                                        new ThreeOfHearts()
                                    };

            info.SecondPairOfCards = new ICard[]
                                     {
                                         new FourOfSpades(),
                                         new FourOfHearts()
                                     };

            info.HighestCard = new FiveOfSpades();

            UpdateCards(info);
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
                            actual[0]);
            Assert.AreEqual(m_InfoTwo,
                            actual[1]);
        }

        [Test]
        public void Apply_Updates_Ranked_For_Multiple_Winners_OtherCards()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2H2S3H3S4H(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.Ranked.ToArray();

            Assert.AreEqual(2,
                            actual.Count());
            Assert.AreEqual(m_InfoOne,
                            actual[0]);
            Assert.AreEqual(m_InfoTwo,
                            actual[1]);
        }

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner_FirstPairOfCards()
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
                            actual[0]);
            Assert.AreEqual(m_InfoOne,
                            actual[1]);
        }

        [Test]
        public void Apply_Updates_Ranked_For_Single_Winner_OtherCards()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2H2S3H3S5C(m_InfoTwo);

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
        public void Apply_Updates_Ranked_For_Single_Winner_SecondPairOfCards()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2S2H4S4H5S(m_InfoTwo);

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
        public void Apply_Updates_Winner_For_Multiple_Winners_OtherCards()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2H2S3H3S4H(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.MultipleWinners,
                            m_Sut.Winner);
        }

        [Test]
        public void Apply_Updates_Winner_For_Single_Winner_FirstPairOfCards()
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

        [Test]
        public void Apply_Updates_Winner_For_Single_Winners_OtherCards()
        {
            // Arrange
            Create2C2D3C3D4C(m_InfoOne);
            Create2H2S3H3S5C(m_InfoTwo);

            // Act
            m_Sut.Apply(m_Infos);

            // Assert
            Assert.AreEqual(WinnerStatus.SingleWinner,
                            m_Sut.Winner);
        }
    }
}
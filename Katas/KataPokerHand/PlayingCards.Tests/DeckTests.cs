using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace PlayingCards.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class DeckTests
    {
        [SetUp]
        public void Setup()
        {
            m_Random = Substitute.For <IRandom>();
            m_Previous = Substitute.For <IPreviousCardValueFinder>();
            m_Next = Substitute.For <INextCardValueFinder>();
            m_Cards = CreateCards();

            m_Sut = new DeckTest(m_Random,
                                 m_Previous,
                                 m_Next,
                                 m_Cards);
        }

        private IRandom m_Random;
        private IPreviousCardValueFinder m_Previous;
        private INextCardValueFinder m_Next;
        private ICard[] m_Cards;
        private DeckTest m_Sut;

        private class DeckTest
            : Deck
        {
            public DeckTest(
                [NotNull] IRandom random,
                [NotNull] IPreviousCardValueFinder previous,
                [NotNull] INextCardValueFinder next,
                [NotNull] IEnumerable <ICard> cards)
                : base(random,
                       previous,
                       next,
                       cards)
            {
            }
        }

        private ICard[] CreateCards()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new ThreeOfClubs(),
                       new FourOfClubs()
                   };
        }

        private void RemoveAllCardsFromDeck()
        {
            for ( var i = 0 ; i < m_Sut.CardsInDeck.Count() ; i++ )
            {
                m_Sut.DrawCard();
            }
        }

        [Test]
        public void AnyCardsLeftInDeck_Returns_False_For_No_Cards_Left()
        {
            // Arrange
            RemoveAllCardsFromDeck();

            // Act
            // Assert
            Assert.False(m_Sut.AnyCardsLeftInDeck);
        }

        [Test]
        public void AnyCardsLeftInDeck_Returns_True_For_Cards_Left()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(m_Sut.AnyCardsLeftInDeck);
        }

        [Test]
        public void CardsLeftInDeck_Returns_Count()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(3,
                            m_Sut.CardsLeftInDeck);
        }

        [Test]
        public void Constructor_Sets_Cards()
        {
            // Arrange
            // Act
            ICard[] actual = m_Sut.Cards.ToArray();

            // Assert
            Assert.AreEqual(3,
                            actual.Length);
            Assert.AreEqual("2C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("3C",
                            actual [ 1 ].ToString());
            Assert.AreEqual("4C",
                            actual [ 2 ].ToString());
        }


        [Test]
        public void Constructor_Sets_CardsInDeck()
        {
            // Arrange
            // Act
            ICard[] actual = m_Sut.CardsInDeck.ToArray();

            // Assert
            Assert.AreEqual(3,
                            actual.Length);
            Assert.AreEqual("2C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("3C",
                            actual [ 1 ].ToString());
            Assert.AreEqual("4C",
                            actual [ 2 ].ToString());
        }

        [Test]
        public void DrawCard_Returns_Card()
        {
            // Arrange
            // Act
            ICard actual = m_Sut.DrawCard();

            // Assert
            Assert.AreEqual("2C",
                            actual.ToString());
        }

        [Test]
        public void DrawCard_Returns_Different_Card_When_Called_Multiple_Times()
        {
            // Arrange
            // Act
            ICard actual1 = m_Sut.DrawCard();
            ICard actual2 = m_Sut.DrawCard();

            // Assert
            Assert.AreEqual("2C",
                            actual1.ToString());
            Assert.AreEqual("3C",
                            actual2.ToString());
        }

        [Test]
        public void DrawCard_Returns_Unknown_For_No_Cards_Left()
        {
            // Arrange
            RemoveAllCardsFromDeck();

            // Act

            ICard actual = m_Sut.DrawCard();

            // Assert
            Assert.AreEqual("UU",
                            actual.ToString());
        }

        [Test]
        public void DrawCards_Returns_All_Cards_Left()
        {
            // Arrange
            // Act
            ICard[] actual = m_Sut.DrawCards(20).ToArray();

            // Assert
            Assert.AreEqual(3,
                            actual.Length);
            Assert.AreEqual("2C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("3C",
                            actual [ 1 ].ToString());
            Assert.AreEqual("4C",
                            actual [ 2 ].ToString());
        }

        [Test]
        public void DrawCards_Returns_Cards()
        {
            // Arrange
            // Act
            ICard[] actual = m_Sut.DrawCards(2).ToArray();

            // Assert
            Assert.AreEqual(2,
                            actual.Length);
            Assert.AreEqual("2C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("3C",
                            actual [ 1 ].ToString());
        }

        [Test]
        public void DrawCards_Returns_Empty_For_No_Cards_Left()
        {
            // Arrange
            RemoveAllCardsFromDeck();

            // Act
            ICard[] actual = m_Sut.DrawCards(20).ToArray();

            // Assert
            Assert.AreEqual(0,
                            actual.Length);
        }

        [Test]
        public void NextCardValue_Calls_NextCardValue()
        {
            // Arrange
            m_Next.NextCardValue(Arg.Any <char>()).Returns('?');

            // Act
            char actual = m_Sut.NextCardValue('2');

            // Assert
            Assert.AreEqual('?',
                            actual);
        }

        [Test]
        public void PreviousCardValue_Calls_PreviousCardValue()
        {
            // Arrange
            m_Previous.PreviousCardValue(Arg.Any <char>()).Returns('?');

            // Act
            char actual = m_Sut.PreviousCardValue('2');

            // Assert
            Assert.AreEqual('?',
                            actual);
        }

        [Test]
        public void Reset_Resets_Cards()
        {
            // Arrange
            m_Random.Next(Arg.Any <int>(),
                          Arg.Any <int>()).Returns(1,
                                                   2,
                                                   1);
            m_Sut.Shuffle();

            // Act
            m_Sut.Reset();

            // Assert
            ICard[] actual = m_Sut.Cards.ToArray();

            Assert.AreEqual(3,
                            actual.Length);
            Assert.AreEqual("2C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("3C",
                            actual [ 1 ].ToString());
            Assert.AreEqual("4C",
                            actual [ 2 ].ToString());
        }

        [Test]
        public void Shuffle_Changes_CardOrder()
        {
            // Arrange
            m_Random.Next(Arg.Any <int>(),
                          Arg.Any <int>()).Returns(1,
                                                   2,
                                                   1);

            // Act
            m_Sut.Shuffle();

            // Assert
            ICard[] actual = m_Sut.Cards.ToArray();

            Assert.AreEqual(3,
                            actual.Length);
            Assert.AreEqual("3C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("2C",
                            actual [ 1 ].ToString());
            Assert.AreEqual("4C",
                            actual [ 2 ].ToString());
        }
    }
}
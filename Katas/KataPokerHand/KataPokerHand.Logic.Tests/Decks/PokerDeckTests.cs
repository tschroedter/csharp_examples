using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Decks;
using KataPokerHand.Logic.Decks.CardValues;
using KataPokerHand.Logic.Decks.Suits;
using KataPokerHand.Logic.Interfaces.CardValues;
using KataPokerHand.Logic.Interfaces.Suits;
using NUnit.Framework;
using static System.Console;

namespace KataPokerHand.Logic.Tests.Decks
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PokerDeckTests
    {
        [SetUp]
        public void Setup()
        {
            IEnumerable <ISuit> suits = CreateSuits();
            IEnumerable <ICardValue> cardValues = CreateCardValues();

            m_Sut = new PokerDeck(suits,
                                  cardValues);
        }

        [TestCase("2C")]
        [TestCase("3C")]
        [TestCase("2H")]
        [TestCase("3H")]
        public void Initialize_Populates_Cards(
            [NotNull] string expected)
        {
            // Arrange
            WriteLine("Looking for card " + expected + "...");

            // Act
            m_Sut.Initialize();

            // Assert
            Assert.True(m_Sut.Cards.Any(x => expected == x.ToString()));
        }

        private IEnumerable <ICardValue> CreateCardValues()
        {
            return new ICardValue[]
                   {
                       new Two(),
                       new Three()
                   };
        }

        private IEnumerable <ISuit> CreateSuits()
        {
            return new ISuit[]
                   {
                       new Club(),
                       new Heart()
                   };
        }

        private PokerDeck m_Sut;


        [Test]
        public void Initialize_Populates_Cards_Length_Test()
        {
            // Arrange
            // Act
            m_Sut.Initialize();

            // Assert
            Assert.AreEqual(4,
                            m_Sut.Cards.Count());
        }

        [Test]
        public void Initialize_Populates_Cards_With_3C()
        {
            // Arrange
            // Act
            m_Sut.Initialize();

            // Assert
            Assert.AreEqual("2C",
                            m_Sut.Cards.ElementAt(0).ToString());
        }
    }
}
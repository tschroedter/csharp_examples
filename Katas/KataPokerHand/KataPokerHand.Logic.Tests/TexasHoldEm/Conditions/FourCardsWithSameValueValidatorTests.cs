using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourCardsWithSameValueValidatorTests
    {
        private FourCardsWithSameValueValidator m_Sut;

        [SetUp]
        public void Setup() // todo use AutoFixture
        {
            m_Sut = new FourCardsWithSameValueValidator();
        }

        [Test]
        public void IsSatisfied_Returns_False_For_Not_Four_Cards_Same_Value()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithNotFourSameValue();

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Four_Cards_Same_Value()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithFourSameValue();

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Four_Cards_Same_Value_Version2()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithFourSameValueVersion2();

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        private ICard[] CreateCardsWithFourSameValue()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new TwoOfSpades(),
                       new AceOfHearts()
                   };
        }

        private ICard[] CreateCardsWithFourSameValueVersion2()
        {
            return new ICard[]
                   {
                       new AceOfHearts(),
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new TwoOfSpades()
                   };
        }

        private ICard[] CreateCardsWithNotFourSameValue()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new KingOfSpades(),
                       new AceOfHearts()
                   };
        }
    }
}
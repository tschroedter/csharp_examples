using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Decks.Cards;
using KataPokerHand.Logic.Interfaces.CardValues;
using KataPokerHand.Logic.Interfaces.Suits;
using NSubstitute;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Cards
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class CardTests
    {
        [SetUp]
        public void Setup()
        {
            m_Suit = Substitute.For <ISuit>();
            m_Value = Substitute.For <ICardValue>();

            m_Sut = new Card(m_Suit,
                             m_Value);
        }

        private ISuit m_Suit;
        private ICardValue m_Value;
        private Card m_Sut;

        [Test]
        public void HasMultipleValues_Returns_False_For_Single_Value()
        {
            // Arrange
            m_Value.Values.Returns(new[]
                                   {
                                       2u
                                   });

            var sut = new Card(m_Suit,
                               m_Value);

            // Act
            // Assert
            Assert.False(sut.HasMultipleValues);
        }

        [Test]
        public void HasMultipleValues_Returns_True_For_Multiple_Values()
        {
            // Arrange
            m_Value.Values.Returns(new[]
                                   {
                                       2u,
                                       3u
                                   });

            var sut = new Card(m_Suit,
                               m_Value);

            // Act
            // Assert
            Assert.True(sut.HasMultipleValues);
        }

        [Test]
        public void Suit_Returns_Suit()
        {
            // Arrange
            m_Suit.AsChar.Returns('C');

            var sut = new Card(m_Suit,
                               m_Value);

            // Act
            char actual = sut.Suit;

            // Assert
            Assert.AreEqual('C',
                            actual);
        }

        [Test]
        public void ToString_Returns_String()
        {
            // Arrange
            m_Suit.AsChar.Returns('C');
            m_Value.AsChar.Returns('2');

            var sut = new Card(m_Suit,
                               m_Value);

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual("2C",
                            actual);
        }

        [Test]
        public void Value_Returns_Value()
        {
            // Arrange
            m_Value.Value.Returns(2u);

            var sut = new Card(m_Suit,
                               m_Value);

            // Act
            uint actual = sut.Value;

            // Assert
            Assert.AreEqual(2u,
                            actual);
        }

        [Test]
        public void Values_Returns_Values()
        {
            // Arrange
            var expected = new[]
                           {
                               2u,
                               3u
                           };
            m_Value.Values.Returns(expected);

            var sut = new Card(m_Suit,
                               m_Value);

            // Act
            IEnumerable <uint> actual = sut.Values;

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }
    }
}
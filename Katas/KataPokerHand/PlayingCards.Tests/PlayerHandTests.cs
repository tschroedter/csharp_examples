using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace PlayingCards.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PlayerHandTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new PlayerHand(new ICard[]
                                   {
                                       new TwoOfClubs(),
                                       new ThreeOfClubs()
                                   });
        }

        private PlayerHand m_Sut;

        [Test]
        public void Cards_Returns_Cards()
        {
            // Arrange
            // Act
            ICard[] actual = m_Sut.Cards.ToArray();

            // Assert
            Assert.AreEqual(2,
                            actual.Length);
            Assert.AreEqual("2C",
                            actual [ 0 ].ToString());
            Assert.AreEqual("3C",
                            actual [ 1 ].ToString());
        }

        [Test]
        public void ToString_Returns_String_For_Empty()
        {
            // Arrange
            var sut = new PlayerHand();

            // Act
            // Assert
            Assert.AreEqual("",
                            sut.ToString());
        }

        [Test]
        public void ToString_Returns_String_For_Given_Cards()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual("2C 3C",
                            m_Sut.ToString());
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataPokerHand.Logic.Decks.Cards;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Cards.Clubs
{
    [ExcludeFromCodeCoverage]
    internal class BaseClubsTests <T>
        where T : ICard, new()
    {
        [NotNull]
        private readonly string m_ExpectedValueAndSuite;

        protected BaseClubsTests(
            [NotNull] string expectedValueAndSuite)
        {
            m_ExpectedValueAndSuite = expectedValueAndSuite;
        }

        [Test]
        public void Constructor_Returns_Instance()
        {
            // Arrange
            var sut = new T();

            // Act
            // Assert
            Assert.AreEqual(m_ExpectedValueAndSuite,
                            sut.ToString());
        }
    }
}
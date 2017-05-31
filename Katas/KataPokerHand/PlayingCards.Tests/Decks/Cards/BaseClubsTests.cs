using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards
{
    [ExcludeFromCodeCoverage]
    internal class BaseClubsTests <T>
        where T : ICard, new()
    {
        protected BaseClubsTests(
            [NotNull] string expectedValueAndSuite)
        {
            m_ExpectedValueAndSuite = expectedValueAndSuite;
        }

        [NotNull]
        private readonly string m_ExpectedValueAndSuite;

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
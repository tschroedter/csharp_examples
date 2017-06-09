using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards
{
    [ExcludeFromCodeCoverage]
    internal class BaseCardTests <T>
        where T : ICard, new()
    {
        protected BaseCardTests(
            [NotNull] string expectedValueAndSuite,
            [NotNull] string expectedDescription,
            CardRank rank)
        {
            m_ExpectedValueAndSuite = expectedValueAndSuite;
            m_ExpectedDescription = expectedDescription;
            m_ExpectedRank = rank;
        }

        private readonly string m_ExpectedDescription;

        private readonly CardRank m_ExpectedRank;

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

        [Test]
        public void Constructor_Sets_Rank()
        {
            // Arrange
            var sut = new T();

            // Act
            // Assert
            Assert.AreEqual(m_ExpectedRank,
                            sut.Rank);
        }

        [Test]
        public void Description_Returns_String()
        {
            // Arrange
            var sut = new T();

            // Act
            // Assert
            Assert.AreEqual(m_ExpectedDescription,
                            sut.Description());
        }
    }
}
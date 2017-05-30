using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using PlayingCards.Decks.Suits;
using NUnit.Framework;

namespace Playing.Tests.Decks.Suits
{
    [ExcludeFromCodeCoverage]
    internal class BaseSuitTests <T>
        where T : BaseSuit, new()
    {
        public BaseSuitTests(
            [NotNull] string name)
        {
            m_ExpectedName = name;
            m_ExpectedAsChar = name [ 0 ];
        }

        private readonly char m_ExpectedAsChar;

        private readonly string m_ExpectedName;

        private T m_Sut;

        [Test]
        public void AsChar_Returns_String()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(m_ExpectedAsChar,
                            m_Sut.AsChar);
        }

        [Test]
        public void Name_Returns_String()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(m_ExpectedName,
                            m_Sut.Name);
        }

        [SetUp]
        public void Setup()
        {
            m_Sut = new T();
        }

        [Test]
        public void ToString_Returns_String()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(m_ExpectedAsChar.ToString(),
                            m_Sut.ToString());
        }
    }
}
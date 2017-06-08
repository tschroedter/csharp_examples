using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [ExcludeFromCodeCoverage]
    internal class BaseCardValueTests <T>
        where T : BaseCardValue, new()
    {
        public BaseCardValueTests(
            char asChar,
            [NotNull] string name,
            [NotNull] uint[] values)
        {
            m_ExpectedName = name;
            m_ExpectedAsChar = asChar;
            m_ExpectedValues = values;
            m_ExpectedValue = values [ 0 ];
        }

        private readonly char m_ExpectedAsChar;

        [NotNull]
        private readonly string m_ExpectedName;

        private readonly uint m_ExpectedValue;

        [NotNull]
        private readonly uint[] m_ExpectedValues;

        private T m_Sut;

        [Test]
        public void AsChar_Returns_Character()
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

        [Test]
        public void Value_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(m_ExpectedValue,
                            m_Sut.Value);
        }

        [Test]
        public void Values_Returns_Values()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(m_ExpectedValues.SequenceEqual(m_Sut.Values));
        }
    }
}
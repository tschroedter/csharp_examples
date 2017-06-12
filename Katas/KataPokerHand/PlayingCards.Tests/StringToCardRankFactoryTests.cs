using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StringToCardRankFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new StringToCardRankFactory();
        }

        private StringToCardRankFactory m_Sut;


        [TestCase("Two",
            CardRank.Two)]
        [TestCase("two",
            CardRank.Two)]
        [TestCase("tWo",
            CardRank.Two)]
        [TestCase("TWO",
            CardRank.Two)]
        [TestCase("???",
            CardRank.Unknown)]
        public void ToCardRank_Returns_CardRank(
            [NotNull] string text,
            CardRank expected)
        {
            // Arrange
            // Act
            CardRank actual = m_Sut.ToCardRank(text);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}
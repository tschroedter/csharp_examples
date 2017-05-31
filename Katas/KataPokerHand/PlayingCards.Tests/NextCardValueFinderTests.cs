using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace PlayingCards.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NextCardValueFinderTests
    {
        [TestCase('U',
            'U')]
        [TestCase('2',
            '3')]
        [TestCase('3',
            '4')]
        [TestCase('4',
            '5')]
        [TestCase('5',
            '6')]
        [TestCase('6',
            '7')]
        [TestCase('7',
            '8')]
        [TestCase('8',
            '9')]
        [TestCase('9',
            'J')]
        [TestCase('J',
            'Q')]
        [TestCase('Q',
            'K')]
        [TestCase('K',
            'A')]
        [TestCase('A',
            'U')]
        public void NextCardValue_Returns_NextCardValue(
            char current,
            char expected)
        {
            // Arrange
            var sut = new NextCardValueFinder();

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.NextCardValue(current));
        }
    }
}
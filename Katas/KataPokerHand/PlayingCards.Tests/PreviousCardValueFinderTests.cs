using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace PlayingCards.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PreviousCardValueFinderTests
    {
        [TestCase('U',
            'U')]
        [TestCase('2',
            'U')]
        [TestCase('3',
            '2')]
        [TestCase('4',
            '3')]
        [TestCase('5',
            '4')]
        [TestCase('6',
            '5')]
        [TestCase('7',
            '6')]
        [TestCase('8',
            '7')]
        [TestCase('9',
            '8')]
        [TestCase('J',
            '9')]
        [TestCase('Q',
            'J')]
        [TestCase('K',
            'Q')]
        [TestCase('A',
            'K')]
        public void PreviousCardValue_Returns_PreviousCardValue(
            char current,
            char expected)
        {
            // Arrange
            var sut = new PreviousCardValueFinder();

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.PreviousCardValue(current));
        }
    }
}
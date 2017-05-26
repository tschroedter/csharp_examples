using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Minesweeper.Logic.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MinesweeperRandomTests
    {
        [Test]
        public void Next_ReturnsRandomNumber_WhenCalled()
        {
            // Arrange
            var sut = new MinesweeperRandom();

            // Act
            int actual = sut.Next(1,
                                  10);

            // Assert
            Assert.True(( actual >= 1 ) && ( actual <= 10 ));
        }
    }
}
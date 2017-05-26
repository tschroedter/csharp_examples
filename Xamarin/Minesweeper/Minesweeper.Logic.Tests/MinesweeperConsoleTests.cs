using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Minesweeper.Logic.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MinesweeperConsoleTests
    {
        [Test]
        public void Write_DoesNotThrow_ForString()
        {
            // Arrange
            var sut = new MinesweeperConsole();

            // Act
            // Assert
            Assert.DoesNotThrow(() => sut.Write(string.Empty));
        }

        [Test]
        public void WriteLine_DoesNotThrow_ForString()
        {
            // Arrange
            var sut = new MinesweeperConsole();

            // Act
            // Assert
            Assert.DoesNotThrow(() => sut.WriteLine(string.Empty));
        }

        [Test]
        public void WriteLine_DoesNotThrow_ForStringAndArgs()
        {
            // Arrange
            var sut = new MinesweeperConsole();

            // Act
            // Assert
            Assert.DoesNotThrow(() => sut.WriteLine(string.Empty,
                                                    1,
                                                    2));
        }
    }
}
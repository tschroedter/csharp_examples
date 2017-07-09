using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SubTotalCalculatorTests
    {
        private const double Delta = 0.001d;

        [Test]
        public void Calculate_Updates_Total()
        {
            // Arrange
            var items = new IReceiptItem[]
                        {
                            new ReceiptItem(1,
                                            "One",
                                            2.0d),
                            new ReceiptItem(3,
                                            "Two",
                                            4.0d)
                        };

            var sut = new SubTotalCalculator();

            // Act
            sut.Calculate(items);

            // Assert
            Assert.True(Math.Abs(14.0d - sut.Total) < Delta);
        }
    }
}
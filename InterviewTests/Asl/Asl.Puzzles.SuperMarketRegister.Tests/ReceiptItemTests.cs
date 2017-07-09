using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ReceiptItemTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new ReceiptItem(2,
                                    "Test",
                                    3.0);
        }

        private const double Delta = 0.001;

        private ReceiptItem m_Sut;

        [Test]
        public void Constructor_Sets_ItemDescription()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual("Test",
                            m_Sut.ItemDescription);
        }

        [Test]
        public void Constructor_Sets_PricePerItem()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(Math.Abs(m_Sut.PricePerItem - 3.0) < Delta);
        }

        [Test]
        public void Constructor_Sets_Quantity()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(2,
                            m_Sut.Quantity);
        }

        [Test]
        public void Constructor_Sets_Total()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(Math.Abs(m_Sut.Total - 6.0) < Delta);
        }

        [Test]
        public void ToString_Returns_Text()
        {
            // Arrange
            const string expected = "2 Test @ $3.00 = $6.00";

            // Act
            string actual = m_Sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}
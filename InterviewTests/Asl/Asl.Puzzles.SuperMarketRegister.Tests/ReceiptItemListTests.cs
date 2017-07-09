using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ReceiptItemListTests
    {
        [SetUp]
        public void Setup()
        {
            m_Item = new ReceiptItem(1,
                                     "Test",
                                     2.0);

            m_Sut = new ReceiptItemList();
        }

        private ReceiptItemList m_Sut;
        private IReceiptItem m_Item;

        [Test]
        public void AddItem_Adds_Item()
        {
            // Arrange
            // Act
            m_Sut.AddItem(m_Item);

            // Assert
            Assert.AreEqual(1,
                            m_Sut.Count);
        }

        [Test]
        public void ToString_Returns_Text()
        {
            // Arrange
            string expected = "1 Test @ $2.00 = $2.00" + Environment.NewLine;

            m_Sut.AddItem(m_Item);

            // Act
            string actual = m_Sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}
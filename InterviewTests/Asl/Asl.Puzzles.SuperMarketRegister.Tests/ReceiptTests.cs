using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ReceiptTests
    {
        [SetUp]
        public void Setup()
        {
            var mocker = new NSubstituteAutoMocker <Receipt>();

            m_List = mocker.Get <IReceiptItemList>();
            m_SubTotalCalculator = mocker.Get <ISubTotalCalculator>();
            m_TaxTotalCalulator = mocker.Get <ITaxTotalCalulator>();
            m_TotalCalculator = mocker.Get <ITotalCalculator>();

            m_Sut = new Receipt(m_List,
                                m_SubTotalCalculator,
                                m_TaxTotalCalulator,
                                m_TotalCalculator);
        }

        private const double Delta = 0.001;

        private Receipt m_Sut;
        private IReceiptItemList m_List;
        private ISubTotalCalculator m_SubTotalCalculator;
        private ITaxTotalCalulator m_TaxTotalCalulator;
        private ITotalCalculator m_TotalCalculator;

        [Test]
        public void AddItem_Adds_Item_To_List()
        {
            // Arrange

            // Act
            m_Sut.AddItem(1,
                          "Test",
                          2.0);

            // Assert
            m_List.Received().AddItem(Arg.Is <IReceiptItem>(x => ( x.Quantity == 1 ) &&
                                                                 x.ItemDescription.Equals("Test") &&
                                                                 ( Math.Abs(x.PricePerItem - 2.0d) < Delta )));
        }

        [Test]
        public void Calculate_Calls_SubTotalCalculator()
        {
            // Arrange
            var items = new IReceiptItem[0];
            m_List.Items.Returns(items);

            // Act
            m_Sut.Calculate();

            // Assert
            m_SubTotalCalculator.Received().Calculate(items);
        }

        [Test]
        public void Calculate_Calls_TaxTotalCalulator()
        {
            // Arrange
            var items = new IReceiptItem[0];
            m_List.Items.Returns(items);

            // Act
            m_Sut.Calculate();

            // Assert
            m_TaxTotalCalulator.Received().Calculate(items);
        }

        [Test]
        public void Calculate_Calls_TotalCalulator_Calculate()
        {
            // Arrange
            var items = new IReceiptItem[0];
            m_List.Items.Returns(items);

            // Act
            m_Sut.Calculate();

            // Assert
            m_TotalCalculator.Received().Calculate(items);
        }

        [Test]
        public void Calculate_Calls_TotalCalulator_SubTotal()
        {
            // Arrange
            m_SubTotalCalculator.Total.Returns(123.0d);

            var items = new IReceiptItem[0];
            m_List.Items.Returns(items);

            // Act
            m_Sut.Calculate();

            // Assert
            Assert.True(Math.Abs(123.0d - m_TotalCalculator.SubTotal) < Delta);
        }

        [Test]
        public void Calculate_Calls_TotalCalulator_TaxTotal()
        {
            // Arrange
            m_TaxTotalCalulator.Total.Returns(123.0d);

            var items = new IReceiptItem[0];
            m_List.Items.Returns(items);

            // Act
            m_Sut.Calculate();

            // Assert
            Assert.True(Math.Abs(123.0d - m_TotalCalculator.TaxTotal) < Delta);
        }

        [Test]
        public void ToString_Returns_String()
        {
            // Arrange
            m_List.ToString().Returns("List" + Environment.NewLine);
            m_SubTotalCalculator.Total.Returns(1.0d);
            m_TaxTotalCalulator.Total.Returns(2.0d);
            m_TaxTotalCalulator.Percentage.Returns(3.0d);
            m_TotalCalculator.Total.Returns(4.0d);

            string expected =
                @"List" +
                Environment.NewLine +
                @"SubTotal = $1.00" +
                Environment.NewLine +
                @"Tax (3%) = $2.00" +
                Environment.NewLine +
                @"Total = $4.00" +
                Environment.NewLine;

            // Act
            string actual = m_Sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Common;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using Autofac;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Integration.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReceiptTests
    {
        [SetUp]
        public void Setup()
        {
            IContainer container = CreateContainer();

            m_Sut = container.Resolve <IReceipt>();
        }

        private IReceipt m_Sut;

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule <LoggingModule>();
            builder.RegisterModule <SuperMarketRegisterModule>();

            IContainer container = builder.Build();

            return container;
        }

        [Test]
        public void TestPurchase()
        {
            // Arrange
            string expected =
                @"1 Candy Bar @ $0.50 = $0.50" +
                Environment.NewLine +
                @"2 Soda @ $1.00 = $2.00" +
                Environment.NewLine +
                @"SubTotal = $2.50" +
                Environment.NewLine +
                @"Tax (10%) = $0.25" +
                Environment.NewLine +
                @"Total = $2.75" +
                Environment.NewLine;

            // Act
            m_Sut.AddItem(1,
                          "Candy Bar",
                          0.50);
            m_Sut.AddItem(2,
                          "Soda",
                          1);

            // Assert
            Assert.AreEqual(expected,
                            m_Sut.ToString());
        }
    }
}
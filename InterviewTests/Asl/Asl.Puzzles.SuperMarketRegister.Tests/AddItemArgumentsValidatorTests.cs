using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Aop;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class AddItemArgumentsValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new AddItemArgumentsValidator();
        }

        private AddItemArgumentsValidator m_Sut;

        [Test]
        public void Validate_Does_Not_Throws_For_Everything_Valid()
        {
            // Arrange
            var args = new object[]
                       {
                           1,
                           "Description",
                           2.0d
                       };

            // Act
            // Assert
            Assert.DoesNotThrow(() => m_Sut.Validate(args));
        }

        [Test]
        public void Validate_Throws_For_Empty_ItemDescription()
        {
            // Arrange
            var args = new object[]
                       {
                           1,
                           ""
                       };

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => m_Sut.Validate(args));
        }

        [Test]
        public void Validate_Throws_For_Negative_Quantity()
        {
            // Arrange
            var args = new object[]
                       {
                           -1
                       };

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => m_Sut.Validate(args));
        }

        [Test]
        public void Validate_Throws_For_Null_ItemDescription()
        {
            // Arrange
            var args = new object[]
                       {
                           1,
                           null
                       };

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => m_Sut.Validate(args));
        }

        [Test]
        public void Validate_Throws_For_PricePerItem_Is_Negative()
        {
            // Arrange
            var args = new object[]
                       {
                           1,
                           "Description",
                           -1.0d
                       };

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => m_Sut.Validate(args));
        }
    }
}
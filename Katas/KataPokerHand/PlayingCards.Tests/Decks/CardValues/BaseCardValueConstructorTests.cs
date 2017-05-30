using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class BaseCardValueConstructorTests
    {
        private class BaseCardValueTest
            : BaseCardValue
        {
            public BaseCardValueTest(
                [NotNull] string name,
                [NotNull] uint[] values)
                : base(name,
                       values)
            {
            }
        }

        [Test]
        public void BaseCardValue_Throws_For_Empty_Name()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => new BaseCardValueTest(
                                                                          string.Empty,
                                                                          new[]
                                                                          {
                                                                              1u
                                                                          }));
        }

        [Test]
        public void BaseCardValue_Throws_For_Empty_Values()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => new BaseCardValueTest(
                                                                          "2",
                                                                          new uint[0]));
        }
    }
}
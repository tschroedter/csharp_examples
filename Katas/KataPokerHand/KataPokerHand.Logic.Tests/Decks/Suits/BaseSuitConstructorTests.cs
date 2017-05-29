using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataPokerHand.Logic.Decks.Suits;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class BaseSuitConstructorTests
    {
        private class BaseSuitTest
            : BaseSuit
        {
            public BaseSuitTest([NotNull] string name)
                : base(name)
            {
            }
        }

        [Test]
        public void BaseSuit_Throws_For_Empty_Name()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => new BaseSuitTest(string.Empty));
        }
    }
}
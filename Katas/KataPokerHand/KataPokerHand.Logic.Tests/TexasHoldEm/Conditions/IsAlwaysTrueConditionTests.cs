using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using KataPokerHand.Logic.TexasHoldEm.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsAlwaysTrueConditionTests
    {

        [Test]
        public void Method_Scenario_ExpectedBehavior()
        {
            // Arrange
            var sut = new IsAlwaysTrueCondition();

            // Act
            // Assert
            Assert.True(sut.IsSatisfied());
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using NUnit.Framework.Internal;
using KataPokerHand.Logic.TexasHoldEm.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsAlwaysFalseConditionTests
    {

        [Test]
        public void Method_Scenario_ExpectedBehavior()
        {
            // Arrange
            var sut = new IsAlwaysFalseCondition();

            // Act
            // Assert
            Assert.False(sut.IsSatisfied());
        }
    }
}

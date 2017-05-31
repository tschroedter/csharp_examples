using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Rules.Logic.Conditions;

namespace Rules.Logic.Tests.Rules.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsLessThanTests
    {
        [TestCase(1,
            0,
            true)]
        [TestCase(1,
            2,
            false)]
        public void IsLessThan_Returns_Expected_For_Given(int threshold,
                                                          int actual,
                                                          bool expected)
        {
            // Arrange
            var sut = new IsLessThan
                      {
                          Threshold = threshold,
                          Actual = actual
                      };

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.IsSatisfied());
        }
    }
}
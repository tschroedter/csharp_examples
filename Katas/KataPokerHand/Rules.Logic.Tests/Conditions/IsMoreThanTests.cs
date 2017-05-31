using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Rules.Logic.Conditions;

namespace Rules.Logic.Tests.Rules.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsMoreThanTests
    {
        [TestCase(1,
            0,
            false)]
        [TestCase(1,
            2,
            true)]
        public void IsMoreThan_Returns_Expected_For_Given(int threshold,
                                                          int actual,
                                                          bool expected)
        {
            // Arrange
            var sut = new IsMoreThan
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
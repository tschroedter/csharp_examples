using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Rules.Logic.Conditions;

namespace Rules.Logic.Tests.Rules.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsEqualTests
    {
        [TestCase(1,
            0,
            false)]
        [TestCase(1,
            1,
            true)]
        public void IsSatisfied_Returns_Expected_For_Given(int threshold,
                                                           int actual,
                                                           bool expected)
        {
            // Arrange
            var sut = new IsEqual
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
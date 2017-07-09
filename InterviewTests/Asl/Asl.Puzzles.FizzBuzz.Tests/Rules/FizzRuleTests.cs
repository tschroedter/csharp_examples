using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Rules;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FizzRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new FizzRule();
        }

        private FizzRule m_Sut;

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void CanApply_Returns_bool_for_number(
            int number,
            bool expected)
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.CanApply(number));
        }

        [Test]
        public void Priority_Returns_Number()
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(2,
                            m_Sut.Priority);
        }
    }
}
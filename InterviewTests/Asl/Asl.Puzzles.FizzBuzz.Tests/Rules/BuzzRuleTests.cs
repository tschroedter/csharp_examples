using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Rules;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class BuzzRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new BuzzRule();
        }

        private BuzzRule m_Sut;

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(6, false)]
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
        public void Apply_Returns_Text()
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual("Buzz",
                            m_Sut.Apply(5));
        }

        [Test]
        public void Priority_Returns_Number()
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(3,
                            m_Sut.Priority);
        }
    }
}
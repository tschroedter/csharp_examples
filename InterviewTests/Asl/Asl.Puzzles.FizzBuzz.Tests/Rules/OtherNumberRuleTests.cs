using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Rules;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class OtherNumberRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new OtherNumberRule();
        }

        private OtherNumberRule m_Sut;

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        public void CanApply_Returns_bool(
            int number,
            bool expected)
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.CanApply(number));
        }

        [TestCase(0, "0")]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        public void Apply_Returns_Text(
            int number,
            string expected)
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.Apply(number));
        }

        [Test]
        public void Priority_Returns_Number()
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(4,
                            m_Sut.Priority);
        }
    }
}
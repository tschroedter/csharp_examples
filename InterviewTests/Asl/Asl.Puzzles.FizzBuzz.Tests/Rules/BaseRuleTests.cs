using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Rules;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class BaseRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new TestBaseRule();
        }

        private TestBaseRule m_Sut;

        private class TestBaseRule
            : BaseRule
        {
            public TestBaseRule()
                : base(1)
            {
            }

            protected override bool CheckIfCanApply(int number)
            {
                return ( number % 2 == 0 ) && ( number >= 0 );
            }

            protected override string GetText(int number)
            {
                return "Test";
            }
        }

        [TestCase(1, false)]
        [TestCase(2, true)]
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
            Assert.AreEqual("Test",
                            m_Sut.Apply(2));
        }

        [Test]
        public void Apply_Throws_For_CanApply_Is_False()
        {
            // Arrange 
            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => m_Sut.Apply(-1));
        }

        [Test]
        public void Constructor_Sets_Priority()
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(1,
                            m_Sut.Priority);
        }
    }
}
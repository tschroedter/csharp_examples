using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using Asl.Puzzles.FizzBuzz.Rules;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FizzBuzzRuleTests
    {
        [SetUp]
        public void Setup()
        {
            var mocker = new NSubstituteAutoMocker <FizzBuzzRule>();

            m_FizzRule = mocker.Get <IFizzRule>();
            m_BuzzRule = mocker.Get <IBuzzRule>();

            m_Sut = mocker.ClassUnderTest;
        }

        private FizzBuzzRule m_Sut;
        private IFizzRule m_FizzRule;
        private IBuzzRule m_BuzzRule;

        private const int DoesNotMatter = 0;

        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void CanApply_Returns_Calls_CanApply(
            bool fizzRule,
            bool buzzRule,
            bool expected)
        {
            // Arrange 
            m_FizzRule.CanApply(Arg.Any <int>()).Returns(fizzRule);
            m_BuzzRule.CanApply(Arg.Any <int>()).Returns(buzzRule);

            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.CanApply(DoesNotMatter));
        }

        [Test]
        public void Apply_Returns_Text()
        {
            // Arrange 
            m_FizzRule.CanApply(Arg.Any <int>()).Returns(true);
            m_BuzzRule.CanApply(Arg.Any <int>()).Returns(true);

            // Act
            // Assert
            Assert.AreEqual("FizzBuzz",
                            m_Sut.Apply(15));
        }

        [Test]
        public void Priority_Returns_Number()
        {
            // Arrange 
            // Act
            // Assert
            Assert.AreEqual(1,
                            m_Sut.Priority);
        }
    }
}
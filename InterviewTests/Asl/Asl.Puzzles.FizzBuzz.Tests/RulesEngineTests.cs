using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Interfaces;
using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class RulesEngineTests
    {
        [SetUp]
        public void Setup()
        {
            var mocker = new NSubstituteAutoMocker <RulesEngine>();
            m_Repository = mocker.Get <IRulesRepository>();
            m_RuleOne = Substitute.For <IRule>();
            m_RuleTwo = Substitute.For <IRule>();
            m_Repository.Rules.Returns(new[]
                                       {
                                           m_RuleOne,
                                           m_RuleTwo
                                       });

            m_Sut = mocker.ClassUnderTest;
        }

        private IRulesRepository m_Repository;
        private RulesEngine m_Sut;
        private IRule m_RuleOne;
        private IRule m_RuleTwo;

        [Test]
        public void Apply_Calls_Apply_Of_Rules()
        {
            // Arrange
            m_RuleOne.CanApply(Arg.Any <int>()).Returns(false);
            m_RuleTwo.CanApply(Arg.Any <int>()).Returns(true);
            m_RuleTwo.Apply(Arg.Any <int>()).Returns("Test");

            // Act
            string actual = m_Sut.Apply(1);

            // Assert
            Assert.AreEqual("Test",
                            actual);
        }

        [Test]
        public void Apply_Calls_CanApply_Of_Rules()
        {
            // Arrange
            m_RuleOne.CanApply(Arg.Any <int>()).Returns(false);
            m_RuleTwo.CanApply(Arg.Any <int>()).Returns(false);

            // Act
            Assert.Throws <ArgumentException>(() => m_Sut.Apply(1));

            // Assert
            m_RuleOne.Received().CanApply(1);
            m_RuleTwo.Received().CanApply(1);
        }

        [Test]
        public void Apply_Throws_If_Not_Rule_Applies()
        {
            // Arrange
            m_RuleOne.CanApply(Arg.Any <int>()).Returns(false);
            m_RuleTwo.CanApply(Arg.Any <int>()).Returns(false);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => m_Sut.Apply(1));
        }
    }
}
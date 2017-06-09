using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using Rules.Logic.Interfaces;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EngineTests
    {
        [SetUp]
        public void Setup()
        {
            m_RuleOne = Substitute.For <IRule <ICellInformation>>();
            m_RuleTwo = Substitute.For <IRule <ICellInformation>>();
            m_Information = Substitute.For <ICellInformation>();
        }

        private IRule <ICellInformation> m_RuleOne;
        private IRule <ICellInformation> m_RuleTwo;
        private ICellInformation m_Information;

        private Engine <T> CreateSut <T>(IRule <T> rule = null)
        {
            rule = rule ?? Substitute.For <IRule <T>>();

            var rules = new[]
                        {
                            rule
                        };

            return CreateSut(rules);
        }

        private Engine <T> CreateSut <T>([NotNull] IEnumerable <IRule <T>> rules)
        {
            var automocker = new NSubstituteAutoMocker <Engine <T>>();
            automocker.Get <IRuleRepository <T>>().Rules.Returns(rules);

            var repository = Substitute.For <IRuleRepository <T>>();
            repository.Rules.Returns(rules);

            return automocker.ClassUnderTest;
        }

        [Test]
        public void ApplyRules_CallsApply_WhenCalled()
        {
            // Arrange
            m_RuleOne.IsValid().Returns(true);

            var cells = new[]
                        {
                            m_Information
                        };

            Engine <ICellInformation> sut = CreateSut(m_RuleOne);

            // Act
            sut.ApplyRules(cells);

            // Assert
            m_RuleOne.Received().Apply(m_Information);
        }

        [Test]
        public void ApplyRules_CallsApplyOnlyOnes_WhenCalled()
        {
            // Arrange
            var cells = new[]
                        {
                            m_Information
                        };

            m_RuleOne.Priority.Returns(1);
            m_RuleOne.IsValid().Returns(true);
            m_RuleTwo.Priority.Returns(2);
            m_RuleOne.IsValid().Returns(true);

            var rules = new[]
                        {
                            m_RuleOne,
                            m_RuleTwo
                        };

            Engine <ICellInformation> sut = CreateSut(rules);

            // Act
            sut.ApplyRules(cells);

            // Assert
            m_RuleOne.Received().Apply(m_Information);
            m_RuleTwo.DidNotReceive().Apply(m_Information);
        }

        [Test]
        public void ApplyRules_CallsClearConditions_WhenCalled()
        {
            // Arrange
            var cells = new[]
                        {
                            m_Information
                        };

            Engine <ICellInformation> sut = CreateSut(m_RuleOne);

            // Act
            sut.ApplyRules(cells);

            // Assert
            m_RuleOne.Received().ClearConditions();
        }

        [Test]
        public void ApplyRules_CallsInitialize_WhenCalled()
        {
            // Arrange
            var cells = new[]
                        {
                            m_Information
                        };

            Engine <ICellInformation> sut = CreateSut(m_RuleOne);

            // Act
            sut.ApplyRules(cells);

            // Assert
            m_RuleOne.Received().Initialize(m_Information);
        }
    }
}
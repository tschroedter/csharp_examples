using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using NSubstitute;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class RulesRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            m_RuleOne = Substitute.For <IRule>();
            m_RuleOne.Priority.Returns(2);
            m_RuleTwo = Substitute.For <IRule>();
            m_RuleTwo.Priority.Returns(1);

            m_Rules = new[]
                      {
                          m_RuleOne,
                          m_RuleTwo
                      };

            m_Sut = new RulesRepository(m_Rules);
        }

        private RulesRepository m_Sut;
        private IRule m_RuleOne;
        private IRule m_RuleTwo;
        private IRule[] m_Rules;

        [Test]
        public void Rules_Are_Sorted_By_Priority()
        {
            // Arrange
            // Act
            IRule[] actual = m_Sut.Rules.ToArray();

            // Assert
            Assert.AreEqual(m_RuleTwo,
                            actual [ 0 ]);
            Assert.AreEqual(m_RuleOne,
                            actual [ 1 ]);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class RuleRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            m_RuleOne = Substitute.For <IRule <ICellInformation>>();
            m_RuleOne.Priority.Returns(1);
            m_RuleTwo = Substitute.For <IRule <ICellInformation>>();
            m_RuleTwo.Priority.Returns(2);
            m_Information = Substitute.For <ICellInformation>();

            m_Sut = new RuleRepository <ICellInformation>();
        }

        private ICellInformation m_Information;
        private IRule <ICellInformation> m_RuleOne;
        private IRule <ICellInformation> m_RuleTwo;
        private RuleRepository <ICellInformation> m_Sut;

        [Test]
        public void Add_Adds_Rule()
        {
            // Arrange
            // Act
            m_Sut.Add(m_RuleOne);

            // Assert
            IRule <ICellInformation>[] actual = m_Sut.Rules.ToArray();
            Assert.AreEqual(1,
                            actual.Length);
            Assert.AreEqual(m_RuleOne,
                            actual [ 0 ]);
        }

        [Test]
        public void Add_Adds_Sorts_Rules()
        {
            // Arrange
            // Act
            m_Sut.Add(m_RuleTwo);
            m_Sut.Add(m_RuleOne);

            // Assert
            IRule <ICellInformation>[] actual = m_Sut.Rules.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.AreEqual(m_RuleOne,
                            actual [ 0 ]);
            Assert.AreEqual(m_RuleTwo,
                            actual [ 1 ]);
        }

        [Test]
        public void Add_Adds_Two_Different_Rules()
        {
            // Arrange
            // Act
            m_Sut.Add(m_RuleOne);
            m_Sut.Add(m_RuleTwo);

            // Assert
            IRule <ICellInformation>[] actual = m_Sut.Rules.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.AreEqual(m_RuleOne,
                            actual [ 0 ]);
            Assert.AreEqual(m_RuleTwo,
                            actual [ 1 ]);
        }

        [Test]
        public void Delete_Removes_Existing_Rule()
        {
            // Arrange
            m_Sut.Add(m_RuleOne);
            m_Sut.Add(m_RuleTwo);

            // Act
            m_Sut.Delete(m_RuleOne);

            // Assert
            IRule <ICellInformation>[] actual = m_Sut.Rules.ToArray();
            Assert.AreEqual(1,
                            actual.Length);
            Assert.AreEqual(m_RuleTwo,
                            actual [ 0 ]);
        }

        [Test]
        public void Updates_Updates_Rule()
        {
            // Arrange
            m_Sut.Add(m_RuleOne);

            // Act
            m_Sut.Update(m_RuleOne);

            // Assert
            IRule <ICellInformation>[] actual = m_Sut.Rules.ToArray();
            Assert.AreEqual(1,
                            actual.Length);
            Assert.AreEqual(m_RuleOne,
                            actual [ 0 ]);
        }
    }
}
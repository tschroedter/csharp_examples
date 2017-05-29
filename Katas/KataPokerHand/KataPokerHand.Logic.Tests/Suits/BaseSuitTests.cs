using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataPokerHand.Logic.Suits;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Suits
{
    [ExcludeFromCodeCoverage]
    internal class BaseSuitTests <T>
        where T : BaseSuit, new()
    {
        public BaseSuitTests(
            [NotNull] string name)
        {
            m_ExpectedName = name;
            m_ExpectedId = name [ 0 ].ToString();
        }

        private readonly string m_ExpectedId;

        private readonly string m_ExpectedName;

        private T m_Sut;

        [Test]
        public void Id_Returns_String()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(m_ExpectedId,
                            m_Sut.Id);
        }

        [Test]
        public void Name_Returns_String()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(m_ExpectedName,
                            m_Sut.Name);
        }

        [SetUp]
        public void Setup()
        {
            m_Sut = new T();
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsFullHouseTests
    {
        [SetUp]
        public void Setup()
        {
            m_AutoMocker = new NSubstituteAutoMocker <IsFullHouse>();
            m_Sut = m_AutoMocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker <IsFullHouse> m_AutoMocker;
        private IsFullHouse m_Sut;


        [Test]
        public void IsSatisfied_Calls_Validator()
        {
            // Arrange
            m_AutoMocker.Get <IFullHouseValidator>().IsValid().Returns(true);

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }
    }
}
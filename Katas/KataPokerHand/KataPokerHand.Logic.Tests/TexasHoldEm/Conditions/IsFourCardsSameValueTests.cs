using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsFourCardsSameValueTests
    {
        [SetUp]
        public void Setup()
        {
            m_AutoMocker = new NSubstituteAutoMocker <IsFourCardsSameValue>();
            m_Sut = m_AutoMocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker <IsFourCardsSameValue> m_AutoMocker;
        private IsFourCardsSameValue m_Sut;


        [Test]
        public void IsSatisfied_Calls_Validator()
        {
            // Arrange
            m_AutoMocker.Get <IFourCardsWithSameValueValidator>().IsValid().Returns(true);

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.Cards;
using KataPokerHand.Logic.TexasHoldEm;
using NSubstitute;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsStraightFlushTests
    {
        private IEnumerable <ICard> CreateStraightFlush()
        {
            return new ICard[]
                   {
                       //SubstituteAutoMocker <ICard>()
                   };
        }

        [Test]
        public void IsTrue_Returns_True_For_StraightFlush()
        {
            // Arrange
            var hand = Substitute.For <IHand>();
            hand.Cards.Returns(CreateStraightFlush());

            // Act
            //var actual = m_Sut.IsTrue();

            // Assert
            //Assert.AreEqual(expected, actual);
        }
    }
}
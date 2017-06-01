﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsNumberOfCardsValidTests
    {
        [TestCase(3,
            0,
            false)]
        [TestCase(3,
            3,
            true)]
        public void IsSatisfied_Returns_Expected_For_Given(
            int numberOfCardsRequired,
            int numberOfCards,
            bool expected)
        {
            // Arrange
            var cards = new List <ICard>();

            for ( var i = 0 ; i < numberOfCards ; i++ )
            {
                cards.Add(Substitute.For <ICard>());
            }

            var sut = new IsNumberOfCardsValid
                      {
                          NumberOfCardsRequired = numberOfCardsRequired,
                          Cards = cards.ToArray()
                      };

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.IsSatisfied());
        }
    }
}
﻿using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineOfClubsTests
        : BaseCardTests <NineOfClubs>
    {
        public NineOfClubsTests()
            : base("9C",
                   "Nine of Clubs",
                   CardRank.Nine)
        {
        }
    }
}
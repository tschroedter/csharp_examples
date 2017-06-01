using System.Diagnostics.CodeAnalysis;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseCardCondition
    {
        public ICard CardOne { get; set; }
        public ICard CardTwo { get; set; }

        public abstract bool IsSatisfied();
    }
}
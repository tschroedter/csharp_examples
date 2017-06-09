using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsSuitEqualCondition
        : ICondition
    {
        [NotNull]
        ICard CardOne { get; set; }

        [NotNull]
        ICard CardTwo { get; set; }
    }
}
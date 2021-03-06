using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsTwoPairsCondition
        : ICondition
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }
    }
}
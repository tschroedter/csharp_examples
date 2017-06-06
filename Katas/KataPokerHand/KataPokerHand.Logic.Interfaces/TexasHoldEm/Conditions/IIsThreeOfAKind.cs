using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public interface IIsThreeOfAKind
        : ICondition
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }
    }
}
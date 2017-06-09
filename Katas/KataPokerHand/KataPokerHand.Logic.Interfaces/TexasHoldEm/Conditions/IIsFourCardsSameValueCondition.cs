using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsFourCardsSameValueCondition
        : ICondition
    {
        [NotNull]
        IEnumerable <ICard> Cards { set; }
    }
}
using System.Collections.Generic;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsFullHouse
        : ICondition
    {
        IEnumerable <ICard> Cards { get; set; }
    }
}
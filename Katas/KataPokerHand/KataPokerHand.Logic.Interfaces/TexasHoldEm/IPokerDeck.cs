using System.Collections.Generic;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface IPokerDeck
    {
        IEnumerable <ICard> Cards { get; }
        void Initialize();
    }
}
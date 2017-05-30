using System.Collections.Generic;
using KataPokerHand.Logic.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface IPokerDeck
    {
        IEnumerable <ICard> Cards { get; }
        void Initialize();
    }
}
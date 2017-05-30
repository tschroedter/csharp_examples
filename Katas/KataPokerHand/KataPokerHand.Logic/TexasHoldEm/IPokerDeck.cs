using System.Collections.Generic;
using KataPokerHand.Logic.Decks.Cards;

namespace KataPokerHand.Logic.Decks
{
    public interface IPokerDeck
    {
        IEnumerable <ICard> Cards { get; }
        void Initialize();
    }
}
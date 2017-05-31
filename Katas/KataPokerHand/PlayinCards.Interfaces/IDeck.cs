using System.Collections.Generic;
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayinCards.Interfaces
{
    public interface IDeck
    {
        IEnumerable <ICard> CardsInDeck { get; }
        IEnumerable <ICard> Cards { get; }
        int CardsLeftInDeck { get; }
        bool AnyCardsLeftInDeck { get; }
        ICard DrawCard();
        IEnumerable <ICard> DrawCards(int numberOfCards);
        char NextCardValue(char value);
        char PreviousCardValue(char value);
        void Reset();
        void Shuffle();
    }
}
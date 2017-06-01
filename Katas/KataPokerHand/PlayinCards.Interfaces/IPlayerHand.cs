using System.Collections.Generic;
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayinCards.Interfaces
{
    public interface IPlayerHand
    {
        IEnumerable <ICard> Cards { get; }
    }
}
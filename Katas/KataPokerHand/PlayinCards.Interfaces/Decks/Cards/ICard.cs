using System.Collections.Generic;

namespace PlayinCards.Interfaces.Decks.Cards
{
    public interface ICard
    {
        char Suit { get; }
        uint Value { get; }
        IEnumerable <uint> Values { get; }
        bool HasMultipleValues { get; }
    }
}
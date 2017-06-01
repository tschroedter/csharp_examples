using System.Collections.Generic;

namespace PlayinCards.Interfaces.Decks.Cards
{
    public interface ICard
    {
        char Suit { get; }
        char Value { get; }
        IEnumerable <uint> Values { get; }
        bool HasMultipleValues { get; }
    }
}
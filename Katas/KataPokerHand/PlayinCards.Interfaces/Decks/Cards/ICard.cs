using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Suits;

namespace PlayinCards.Interfaces.Decks.Cards
{
    public interface ICard
    {
        char Suit { get; }
        char Value { get; }
        IEnumerable <uint> Values { get; }
        bool HasMultipleValues { get; }
        CardRank Rank { get; }

        string Description();

        [NotNull]
        ISuit GetSuit(); // todo code smell Suit as char and class
    }
}
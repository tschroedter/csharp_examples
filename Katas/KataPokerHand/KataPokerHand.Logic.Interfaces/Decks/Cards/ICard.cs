using System.Collections.Generic;

namespace KataPokerHand.Logic.Interfaces.Decks.Cards
{
    public interface ICard
    {
        char Suit { get; }
        uint Value { get; }
        IEnumerable <uint> Values { get; }
        bool HasMultipleValues { get; }
    }
}
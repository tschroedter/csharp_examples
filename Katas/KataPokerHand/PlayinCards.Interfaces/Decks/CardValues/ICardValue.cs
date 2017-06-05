using PlayinCards.Interfaces.Decks.Cards;

namespace PlayinCards.Interfaces.Decks.CardValues
{
    public interface ICardValue
    {
        string Name { get; }
        uint[] Values { get; }
        uint Value { get; }
        char AsChar { get; }
        CardRank Rank { get; }
    }
}
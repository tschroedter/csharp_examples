using PlayinCards.Interfaces.Decks.Cards;

namespace PlayinCards.Interfaces
{
    public interface IStringToCardRankFactory
    {
        CardRank ToCardRank(string name);
    }
}
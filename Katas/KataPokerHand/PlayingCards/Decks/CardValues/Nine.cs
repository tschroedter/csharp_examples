using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Nine
        : BaseCardValue
    {
        public Nine()
            : base("9",
                   new[]
                   {
                       9u
                   },
                   CardRank.Nine)
        {
        }
    }
}
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Queen
        : BaseCardValue
    {
        public Queen()
            : base("Queen",
                   new[]
                   {
                       10u
                   },
                   CardRank.Queen)
        {
        }
    }
}
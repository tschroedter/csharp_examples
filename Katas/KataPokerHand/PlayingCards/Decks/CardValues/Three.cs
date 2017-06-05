using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Three
        : BaseCardValue
    {
        public Three()
            : base("3",
                   new[]
                   {
                       3u
                   },
                   CardRank.Three)
        {
        }
    }
}
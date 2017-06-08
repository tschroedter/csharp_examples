using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Four
        : BaseCardValue
    {
        public Four()
            : base('4',
                   "Four",
                   new[]
                   {
                       4u
                   },
                   CardRank.Four)
        {
        }
    }
}
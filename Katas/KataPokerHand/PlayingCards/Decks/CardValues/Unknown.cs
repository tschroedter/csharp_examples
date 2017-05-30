using PlayinCards.Interfaces.Decks.CardValues;

namespace PlayingCards.Decks.CardValues
{
    public class Unknown
        : BaseCardValue
    {
        public static ICardValue UnknownCardValue = new Unknown();

        public Unknown()
            : base("Unknown",
                   new[]
                   {
                       0u
                   })
        {
        }
    }
}
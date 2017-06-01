using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsNumberOfCardsValid // todo testing
        : IIsNumberOfCardsValid
    {
        public int NumberOfCardsRequired { get; }
        public int NumberOfCards { get; }

        public IsNumberOfCardsValid(
            int numberOfCardsRequired,
            [NotNull] ICard[] cards)
        {
            NumberOfCardsRequired = numberOfCardsRequired;
            NumberOfCards = cards.Length;
        }

        public bool IsSatisfied()
        {
            return NumberOfCardsRequired == NumberOfCards;
        }
    }
}
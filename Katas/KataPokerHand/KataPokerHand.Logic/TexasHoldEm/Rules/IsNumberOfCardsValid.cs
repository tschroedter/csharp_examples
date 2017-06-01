using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsNumberOfCardsValid // todo testing
        : IIsNumberOfCardsValid
    {
        public IsNumberOfCardsValid(
            int numberOfCardsRequired,
            [NotNull] ICard[] cards)
        {
            NumberOfCardsRequired = numberOfCardsRequired;
            NumberOfCards = cards.Length;
        }

        public int NumberOfCardsRequired { get; }
        public int NumberOfCards { get; }

        public bool IsSatisfied()
        {
            return NumberOfCardsRequired == NumberOfCards;
        }
    }
}
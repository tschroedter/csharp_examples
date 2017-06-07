using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsNumberOfCardsInvalid
        : IIsNumberOfCardsInvalid
    {
        [NotNull]
        public ICard[] Cards
        {
            set
            {
                NumberOfCards = value.Length;
            }
        }

        public int NumberOfCardsRequired { get; set; }
        public int NumberOfCards { get; private set; }

        public bool IsSatisfied()
        {
            return NumberOfCardsRequired != NumberOfCards;
        }
    }
}
using JetBrains.Annotations;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFourCardsSameValue
        : IIsFourCardsSameValue
    {
        [NotNull]
        private readonly IFourCardsWithSameValueValidator m_Validator;

        public IsFourCardsSameValue(
            [NotNull] IFourCardsWithSameValueValidator validator)
        {
            m_Validator = validator;
            Cards = new ICard[0];
        }

        public bool IsSatisfied()
        {
            m_Validator.Cards = Cards;
            return m_Validator.IsValid();
        }

        public ICard[] Cards { get; set; }
    }
}
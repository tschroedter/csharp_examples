using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFourCardsSameValue
        : IIsFourCardsSameValue
    {
        public IsFourCardsSameValue(
            [NotNull] IFourCardsWithSameValueValidator validator)
        {
            m_Validator = validator;
            Cards = new ICard[0];
        }

        [NotNull]
        private readonly IFourCardsWithSameValueValidator m_Validator;

        public bool IsSatisfied()
        {
            m_Validator.Cards = Cards;
            return m_Validator.IsValid();
        }

        public ICard[] Cards { get; set; }
    }
}
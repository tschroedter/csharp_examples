using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsTwoPairs
        : IIsTwoPairs
    {
        public IsTwoPairs(
            [NotNull] ITwoPairsValidator validator) // todo generic
        {
            m_Validator = validator;
            Cards = new ICard[0];
        }

        [NotNull]
        private readonly ITwoPairsValidator m_Validator;

        public bool IsSatisfied()
        {
            m_Validator.Cards = Cards;
            return m_Validator.IsValid();
        }

        public ICard[] Cards { get; set; }
    }
}
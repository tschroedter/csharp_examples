using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsThreeOfAKind // todo testing
        : IIsThreeOfAKind
    {
        public IsThreeOfAKind(
            [NotNull] IThreeCardsWithSameValueValidator validator)
        {
            m_Validator = validator;
            Cards = new ICard[0];
        }

        [NotNull]
        private readonly IThreeCardsWithSameValueValidator m_Validator;

        public bool IsSatisfied()
        {
            m_Validator.Cards = Cards;
            return m_Validator.IsValid();
        }

        public IEnumerable <ICard> Cards { get; set; }
    }

    public interface IIsThreeOfAKind
        : ICondition
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }
    }
}
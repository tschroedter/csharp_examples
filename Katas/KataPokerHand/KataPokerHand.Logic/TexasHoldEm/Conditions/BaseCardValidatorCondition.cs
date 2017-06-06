using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public abstract class BaseCardValidatorCondition <TValidator>
        where TValidator : class, IValidator
    {
        protected BaseCardValidatorCondition(
            [NotNull] TValidator validator)
        {
            m_Validator = validator;
            Cards = new ICard[0];
        }

        [NotNull]
        public IEnumerable <ICard> Cards { get; set; }

        private readonly TValidator m_Validator;

        public virtual bool IsSatisfied()
        {
            m_Validator.Cards = Cards;

            return m_Validator.IsValid();
        }
    }
}
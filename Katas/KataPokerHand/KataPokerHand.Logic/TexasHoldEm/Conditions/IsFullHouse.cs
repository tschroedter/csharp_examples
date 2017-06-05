using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsFullHouse
        : IIsFullHouse
    {
        public IsFullHouse(
            [NotNull] IFullHouseValidator validator)
        {
            m_Validator = validator;
            Cards = new ICard[0];
        }

        [NotNull]
        private readonly IFullHouseValidator m_Validator;

        public bool IsSatisfied()
        {
            m_Validator.Cards = Cards;
            return m_Validator.IsValid();
        }

        public IEnumerable <ICard> Cards { get; set; }
    }
}
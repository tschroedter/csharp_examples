using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsSameSuitAllCards
        : IIsSameSuitAllCards
    {
        private readonly List <ICondition> m_Conditions = new List <ICondition>();

        [NotNull]
        public ICard[] Cards
        {
            set
            {
                IEnumerable <ICondition> addConditions = AddConditions(value);
                m_Conditions.Clear();
                m_Conditions.AddRange(addConditions);
            }
        }

        public bool IsSatisfied()
        {
            return m_Conditions.All(x => x.IsSatisfied());
        }

        private IEnumerable <ICondition> AddConditions(
            [NotNull] IEnumerable <ICard> cards)
        {
            ICard[] array = cards as ICard[] ?? cards.ToArray();

            if ( !array.Any() )
            {
                return HandleCardsIsEmpty();
            }
            return HandleCards(array);
        }

        private IEnumerable <ICondition> HandleCards(
            [NotNull] ICard[] cards)
        {
            var conditions = new List <ICondition>();

            ICard first = cards [ 0 ];

            foreach ( ICard card in cards )
            {
                conditions.Add(new IsSuitEqual // todo replace with factory
                               {
                                   CardOne = card,
                                   CardTwo = first
                               });
            }

            return conditions;
        }

        private IEnumerable <ICondition> HandleCardsIsEmpty()
        {
            return new[]
                   {
                       new IsAlwaysFalse()
                   };
        }
    }
}
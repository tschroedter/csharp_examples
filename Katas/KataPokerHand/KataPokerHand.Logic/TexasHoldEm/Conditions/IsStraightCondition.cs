using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsStraightCondition
        : IIsStraightCondition
    {
        private readonly List <ICondition> m_Conditions = new List <ICondition>();

        public bool IsSatisfied()
        {
            return m_Conditions.All(x => x.IsSatisfied());
        }

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

        private IEnumerable <ICondition> AddConditions(
            [NotNull] ICard[] cards)
        {
            ICard[] array = cards;

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

            for ( var i = 0 ; i < cards.Length - 1 ; i++ )
            {
                conditions.Add(new IsNextCardValue( // todo factory
                                                   new NextCardValueFinder())
                               {
                                   CardOne = cards [ i ],
                                   CardTwo = cards [ i + 1 ]
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
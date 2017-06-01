using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsStraight
        : IIsStraight
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

        private IEnumerable <ICondition> AddConditions(ICard[] cards)
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
    }
}
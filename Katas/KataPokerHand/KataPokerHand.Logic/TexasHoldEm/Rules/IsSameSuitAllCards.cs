using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
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
            var conditions = new List <ICondition>();

            ICard[] array = cards as ICard[] ?? cards.ToArray();

            ICard first = array [ 0 ];

            foreach ( ICard card in array )
            {
                conditions.Add(new IsSuitEqual // todo replace with factory
                               {
                                   CardOne = card,
                                   CardTwo = first
                               });
            }

            return conditions;
        }
    }
}
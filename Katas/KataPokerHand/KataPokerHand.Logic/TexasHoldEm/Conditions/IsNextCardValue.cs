using JetBrains.Annotations;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Conditions;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsNextCardValue
        : BaseCondition <ICard>,
          ICondition <ICard> // todo testing
    {
        public IsNextCardValue(
            [NotNull] INextCardValueFinder finder)
        {
            m_Finder = finder;
        }

        [NotNull]
        private readonly INextCardValueFinder m_Finder;

        public override bool IsSatisfied()
        {
            char nextCardValue = m_Finder.NextCardValue(Actual.Value);

            return nextCardValue == Threshold.Value;
        }
    }
}
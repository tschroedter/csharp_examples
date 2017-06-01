using JetBrains.Annotations;
using PlayinCards.Interfaces;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsNextCardValue
        : BaseCardCondition,
          ICondition
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
            char nextCardValue = m_Finder.NextCardValue(CardOne.Value);

            return nextCardValue == CardTwo.Value;
        }
    }
}
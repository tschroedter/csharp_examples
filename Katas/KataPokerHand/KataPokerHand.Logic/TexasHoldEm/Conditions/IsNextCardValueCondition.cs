using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsNextCardValueCondition
        : BaseCardCondition,
          IIsNextCardValueCondition
    {
        public IsNextCardValueCondition(
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
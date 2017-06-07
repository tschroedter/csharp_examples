using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsHighCardRule
        : BaseRule<IPlayerHandInformation>,
          IRule<IPlayerHandInformation>
    {
        public IsHighCardRule(
            [NotNull] IIsAlwaysTrue condition)
        {
            m_Condition = condition;
        }

        [NotNull]
        private readonly IIsAlwaysTrue m_Condition;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.HighCard;
            info.HighestCard = info.PlayerHand.Cards.OrderBy(x => x.Rank).Last();

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            Conditions.Add(m_Condition);
        }

        public override int GetPriority()
        {
            return (int)RulesPriority.HighCard;
        }
    }
}
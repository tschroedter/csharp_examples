using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsStraightRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsStraightRule(
            [NotNull] IIsStraightCondition straightCondition)
        {
            m_StraightCondition = straightCondition;
        }

        [NotNull]
        private readonly IIsStraightCondition m_StraightCondition;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Straight;
            info.HighestCard = info.Cards.OrderBy(x => x.Rank).Last();

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.Cards as ICard[] ?? info.Cards.ToArray();

            m_StraightCondition.Cards = cards;

            Conditions.Add(m_StraightCondition);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.Straight;
        }
    }
}
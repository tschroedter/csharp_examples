using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsFlushRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsFlushRule(
            [NotNull] IIsSameSuitAllConditionCards same)
        {
            m_Same = same;
        }

        [NotNull]
        private readonly IIsSameSuitAllConditionCards m_Same;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Flush;
            info.Suit = info.Cards.First().GetSuit();
            info.HighestCard = info.Cards.OrderBy(x => x.Rank).Last();

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.Cards as ICard[] ?? info.Cards.ToArray();

            m_Same.Cards = cards;

            Conditions.Add(m_Same);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.Flush;
        }
    }
}
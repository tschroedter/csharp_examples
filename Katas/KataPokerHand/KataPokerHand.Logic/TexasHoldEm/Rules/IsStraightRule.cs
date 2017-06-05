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
            [NotNull] IIsStraight straight)
        {
            m_Straight = straight;
        }

        [NotNull]
        private readonly IIsStraight m_Straight;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Straight;
            info.HighestCard = info.PlayerHand.Cards.OrderBy(x => x.Rank).Last();

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.PlayerHand.Cards as ICard[] ?? info.PlayerHand.Cards.ToArray();

            m_Straight.Cards = cards;

            Conditions.Add(m_Straight);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.Straight;
        }
    }
}
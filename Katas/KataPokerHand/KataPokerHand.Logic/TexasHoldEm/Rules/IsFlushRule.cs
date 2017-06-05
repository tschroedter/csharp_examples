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
            [NotNull] IIsSameSuitAllCards same)
        {
            m_Same = same;
        }

        [NotNull]
        private readonly IIsSameSuitAllCards m_Same;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Flush;
            info.Suit = info.PlayerHand.Cards.First().GetSuit();
            info.HighestCard = info.PlayerHand.Cards.OrderBy(x => x.Rank).Last();

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.PlayerHand.Cards as ICard[] ?? info.PlayerHand.Cards.ToArray();

            m_Same.Cards = cards;

            Conditions.Add(m_Same);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.Flush;
        }
    }
}
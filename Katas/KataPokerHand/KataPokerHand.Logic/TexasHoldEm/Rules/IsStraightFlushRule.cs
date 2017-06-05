using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsStraightFlushRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsStraightFlushRule(
            [NotNull] IIsSameSuitAllCards same,
            [NotNull] IIsStraight straight)
        {
            m_Same = same;
            m_Straight = straight;
        }

        [NotNull]
        private readonly IIsSameSuitAllCards m_Same;

        [NotNull]
        private readonly IIsStraight m_Straight;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Unknown;
            info.Suit = UnknownSuit.Unknown;
            info.HighestCard = UnknownCard.Unknown;

            if ( !info.PlayerHand.Cards.Any() )
            {
                return info;
            }

            info.Status = Status.StraightFlush;
            info.Suit = info.PlayerHand.Cards.First().GetSuit();
            info.HighestCard = info.PlayerHand.Cards.OrderBy(x => x.Rank).Last();

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.PlayerHand.Cards as ICard[] ?? info.PlayerHand.Cards.ToArray();

            m_Same.Cards = cards;
            m_Straight.Cards = cards;

            Conditions.Add(m_Same);
            Conditions.Add(m_Straight);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.StraightFlush;
        }
    }
}
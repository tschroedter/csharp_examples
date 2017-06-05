using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsFourOfAKindRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsFourOfAKindRule(
            [NotNull] IIsFourCardsSameValue same,
            [NotNull] IFourCardsWithSameValueValidator validator)
        {
            m_Same = same;
            m_Validator = validator;
        }

        [NotNull]
        private readonly IIsFourCardsSameValue m_Same;

        [NotNull]
        private readonly IFourCardsWithSameValueValidator m_Validator;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Unknown;
            info.Suit = UnknownSuit.Unknown;
            info.HighestCard = UnknownCard.Unknown;

            if ( !info.PlayerHand.Cards.Any() )
            {
                return info;
            }

            m_Validator.Cards = info.PlayerHand.Cards;
            if ( m_Validator.IsValid() )
            {
                return info;
            }

            info.Status = Status.FourOfAKind;
            info.Rank = m_Validator.FourCardsRanks;
            info.HighestCard = m_Validator.OtherCard;

            return info;
        }

        public override void Initialize(IPlayerHandInformation info)
        {
            m_Same.Cards = info.PlayerHand.Cards.ToArray();

            Conditions.Add(m_Same);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.FourOfAKind;
        }
    }
}
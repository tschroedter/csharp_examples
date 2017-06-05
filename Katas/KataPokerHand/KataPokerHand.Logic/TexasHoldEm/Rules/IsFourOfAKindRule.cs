using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsFourOfAKindRule // todo testing
        : BaseRule<IPlayerHandInformation>
          , IRule <IPlayerHandInformation>
    {
        private const int NumberOfCardsRequired = 5;

        [NotNull]
        private readonly IIsNumberOfCardsValid m_Valid;

        [NotNull]
        private readonly IIsFourCardsSameValue m_Same;

        [NotNull]
        private readonly IFourCardsWithSameValueValidator m_Validator;

        public IsFourOfAKindRule(
            [NotNull] IIsNumberOfCardsValid valid,
            [NotNull] IIsFourCardsSameValue same,
            [NotNull] IFourCardsWithSameValueValidator validator)
        {
            m_Valid = valid;
            m_Same = same;
            m_Validator = validator;
        }

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.Unknown;
            info.Suit = UnknownSuit.Unknown;
            info.HighestCard = UnknownCard.Unknown;

            if (!info.PlayerHand.Cards.Any())
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

        public override int GetPriority()
        {
            return (int)RulesPriority.FourOfAKind;
        }

        public override void Initialize(IPlayerHandInformation info)
        {
            ICard[] cards = info.PlayerHand.Cards as ICard[] ?? info.PlayerHand.Cards.ToArray();

            if (!cards.Any())
            {
                AddConditionsForCardsEmpty();
            }
            else
            {
                AddConditionsForCards(cards);
            }
        }

        private void AddConditionsForCards(ICard[] cards)
        {
            m_Valid.NumberOfCardsRequired = NumberOfCardsRequired;
            m_Valid.Cards = cards;
            m_Same.Cards = cards;

            Conditions.Add(m_Valid);
            Conditions.Add(m_Same);
        }

        private void AddConditionsForCardsEmpty()
        {
            Conditions.Add(new IsAlwaysFalse());
        }
    }
}
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
    public class IsStraightFlushRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsStraightFlushRule(
            [NotNull] IIsNumberOfCardsValid valid,
            [NotNull] IIsSameSuitAllCards same,
            [NotNull] IIsStraight straight)
        {
            m_Valid = valid;
            m_Same = same;
            m_Straight = straight;
        }

        [NotNull]
        private const int NumberOfCardsRequired = 5;

        [NotNull]
        private readonly IIsSameSuitAllCards m_Same;

        [NotNull]
        private readonly IIsStraight m_Straight;

        [NotNull]
        private readonly IIsNumberOfCardsValid m_Valid;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.StraightFlush;
            info.Suit = UnknownSuit.Unknown.AsChar;
            info.HighestCard = UnknownCard.Unknown.Value;

            if ( !info.PlayerHand.Cards.Any() )
            {
                return info;
            }

            info.Suit = info.PlayerHand.Cards.First().Suit; // todo not sure if more enums
            info.HighestCard = info.PlayerHand.Cards.Max(x => x.Values.First()); // todo testing

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.PlayerHand.Cards as ICard[] ?? info.PlayerHand.Cards.ToArray();

            if ( !cards.Any() )
            {
                AddConditionsForCardsEmpty();
            }
            else
            {
                AddConditionsForCards(cards);
            }
        }

        public override int GetPriority()
        {
            return 2;
        }

        private void AddConditionsForCards(ICard[] cards)
        {
            m_Valid.NumberOfCardsRequired = NumberOfCardsRequired;
            m_Valid.Cards = cards;
            m_Same.Cards = cards;
            m_Straight.Cards = cards;

            Conditions.Add(m_Valid);
            Conditions.Add(m_Same);
            Conditions.Add(m_Straight);
        }

        private void AddConditionsForCardsEmpty()
        {
            Conditions.Add(new IsAlwaysFalse());
        }
    }
}
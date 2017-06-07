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
    public class IsNumberOfCardsIncorrectRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsNumberOfCardsIncorrectRule(
            [NotNull] IIsNumberOfCardsInvalid invalid)
        {
            m_Invalid = invalid;
        }

        [NotNull]
        private const int NumberOfCardsRequired = 5;

        [NotNull]
        private readonly IIsNumberOfCardsInvalid m_Invalid;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.NumberOfCardsIncorrect;
            info.Suit = UnknownSuit.Unknown;
            info.Rank = CardRank.Unknown;
            info.HighestCard = UnknownCard.Unknown;

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.Cards as ICard[] ?? info.Cards.ToArray();

            m_Invalid.NumberOfCardsRequired = NumberOfCardsRequired;
            m_Invalid.Cards = cards;

            Conditions.Add(m_Invalid);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.NumberOfCardsIncorrect;
        }
    }
}
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
            [NotNull] IIsNumberOfCardsInvalidCondition invalidCondition)
        {
            m_InvalidCondition = invalidCondition;
        }

        [NotNull]
        private const int NumberOfCardsRequired = 5;

        [NotNull]
        private readonly IIsNumberOfCardsInvalidCondition m_InvalidCondition;

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

            m_InvalidCondition.NumberOfCardsRequired = NumberOfCardsRequired;
            m_InvalidCondition.Cards = cards;

            Conditions.Add(m_InvalidCondition);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.NumberOfCardsIncorrect;
        }
    }
}
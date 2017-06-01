using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;
using Rules.Logic.Conditions;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsStraightFlushRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        [NotNull]
        private const int NumberOfCardsRequired = 5;


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
                Conditions.Add(new IsAlwaysFalse());
                return;
            }

            ICard first = cards [ 0 ];

            // todo factories
            Conditions.Add(new IsNumberOfCardsValid(NumberOfCardsRequired, cards));
            Conditions.Add(new IsAllSameSuit(cards)); 
            Conditions.Add(new IsStraight(cards));
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsStraightFlushRule
        : BaseRule <IPlayerHandInformation, ICard>,
          IRule <IPlayerHandInformation>
    {
        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            info.Status = Status.StraightFlush;
            info.Suit = info.PlayerHand.Cards.First().Suit; // todo not sure if more enums
            info.HighestCard = info.PlayerHand.Cards.Max(x => x.Values.First()); // todo testing

            return info;
        }

        public override void Initialize(
            [NotNull] IPlayerHandInformation info)
        {
            ICard[] cards = info.PlayerHand.Cards as ICard[] ?? info.PlayerHand.Cards.ToArray();
            ICard first = cards [ 0 ];

            foreach ( ICard card in cards )
            {
                Conditions.Add(new IsSuitEqual // todo replace with factory
                               {
                                   Actual = card,
                                   Threshold = first
                               });
            }

            for ( var i = 0 ; i < cards.Length - 1 ; i++ )
            {
                Conditions.Add(new IsNextCardValue( // todo factory
                                                   new NextCardValueFinder())
                               {
                                   Actual = cards [ i ],
                                   Threshold = cards [ i + 1 ]
                               });
            }
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}
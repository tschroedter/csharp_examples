using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions.Validators
{
    public class OnePairValidator
        : IOnePairValidator
    {
        public OnePairValidator()
        {
            Cards = new ICard[0];
            PairOfCards = new ICard[0];
            OtherCards = new ICard[0];
            HighestCard = UnknownCard.Unknown;
        }

        public IEnumerable <ICard> Cards { get; set; }

        public bool IsValid()
        {
            IEnumerable <CardRank> values = Cards.Select(x => x.Rank);

            IEnumerable <CardRank> cardRanks = values as CardRank[] ?? values.ToArray();
            IEnumerable <IGrouping <CardRank, CardRank>> grouped = cardRanks.GroupBy(x => x).ToArray();

            if ( grouped.Count() != 4 ) // todo test for this
            {
                return false;
            }

            foreach ( IGrouping <CardRank, CardRank> grouping in grouped )
            {
                int count = grouping.Count();

                if ( count != 2 )
                {
                    continue;
                }

                PairOfCards = Cards.Where(x => x.Rank == grouping.Key);
                OtherCards = Cards.Where(x => x.Rank != grouping.Key).ToArray();
                HighestCard = OtherCards.OrderBy(x => x.Rank).Last();
            }

            return PairOfCards.Any() && OtherCards.Any();
        }

        public IEnumerable <ICard> PairOfCards { get; set; }
        public IEnumerable <ICard> OtherCards { get; set; }
        public ICard HighestCard { get; set; }
    }
}
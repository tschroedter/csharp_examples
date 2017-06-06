using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class TwoPairsValidator
        : ITwoPairsValidator
    {
        public TwoPairsValidator()
        {
            Cards = new ICard[0];
            FirstPairOfCards = new ICard[0];
            SecondPairOfCards = new ICard[0];
        }

        public IEnumerable <ICard> Cards { get; set; }

        public bool IsValid()
        {
            IEnumerable <CardRank> values = Cards.Select(x => x.Rank);

            IEnumerable <CardRank> cardRanks = values as CardRank[] ?? values.ToArray();
            IEnumerable <IGrouping <CardRank, CardRank>> grouped = cardRanks.GroupBy(x => x).ToArray();

            if ( grouped.Count() != 3 )
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

                if ( !FirstPairOfCards.Any() )
                {
                    FirstPairOfCards = Cards.Where(x => x.Rank == grouping.Key);
                }
                else
                {
                    SecondPairOfCards = Cards.Where(x => x.Rank == grouping.Key);
                }
            }

            return FirstPairOfCards.Any() && SecondPairOfCards.Any();
        }

        public IEnumerable <ICard> FirstPairOfCards { get; set; }
        public IEnumerable <ICard> SecondPairOfCards { get; set; }
    }
}
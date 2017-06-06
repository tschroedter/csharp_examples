using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions.Validators
{
    public class FullHouseValidator
        : IFullHouseValidator
    {
        public FullHouseValidator()
        {
            NumberOfCardsWithSameValue = 3;
            Cards = new ICard[0];
            TwoOfAKind = new ICard[0];
            ThreeOfAKind = new ICard[0];
        }

        private const int CardCountForThreeOfAKind = 3;
        private const int CardCountForTwoOfAKind = 2;

        public int NumberOfCardsWithSameValue { get; }

        public IEnumerable <ICard> Cards { get; set; }

        public bool IsValid()
        {
            IEnumerable <CardRank> values = Cards.Select(x => x.Rank);

            IEnumerable <CardRank> cardRanks = values as CardRank[] ?? values.ToArray();
            IEnumerable <IGrouping <CardRank, CardRank>> grouped = cardRanks.GroupBy(x => x).ToArray();

            if ( grouped.Count() != 2 )
            {
                return false;
            }

            int first = grouped.First().Count();
            int second = grouped.Last().Count();

            if ( first == CardCountForThreeOfAKind &&
                 second == CardCountForTwoOfAKind )
            {
                ThreeOfAKind = Cards.Where(x => x.Rank == grouped.First().Key);
                TwoOfAKind = Cards.Where(x => x.Rank == grouped.Last().Key);

                return true;
            }

            if ( first == CardCountForTwoOfAKind &&
                 second == CardCountForThreeOfAKind )
            {
                TwoOfAKind = Cards.Where(x => x.Rank == grouped.First().Key);
                ThreeOfAKind = Cards.Where(x => x.Rank == grouped.Last().Key);

                return true;
            }

            return false;
        }

        public IEnumerable <ICard> TwoOfAKind { get; set; }

        public IEnumerable <ICard> ThreeOfAKind { get; set; }
    }
}
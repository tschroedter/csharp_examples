using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class FourCardsWithSameValueValidator
        : IFourCardsWithSameValueValidator
    {
        public FourCardsWithSameValueValidator()
        {
            Cards = new ICard[0];
            OtherCard = UnknownCard.Unknown;
            FourOfAKind = new ICard[0];
        }

        public IEnumerable <ICard> Cards { get; set; }

        public bool IsValid()
        {
            IEnumerable <CardRank> values = Cards.Select(x => x.Rank);

            IEnumerable <CardRank> cardRanks = values as CardRank[] ?? values.ToArray();
            IEnumerable <IGrouping <CardRank, CardRank>> grouped = cardRanks.GroupBy(x => x);

            if ( grouped.Count() != 2 )
            {
                return false;
            }

            bool cardRankOne = AreThereFourCardsWithSameRank(cardRanks.First(),
                                                             cardRanks);

            bool cardRankTwo = AreThereFourCardsWithSameRank(cardRanks.Last(),
                                                             cardRanks);

            if ( cardRankOne )
            {
                FourCardsRanks = cardRanks.First();
                FourOfAKind = Cards.Where(x => x.Rank == cardRanks.First()); // todo testing
                OtherCard = Cards.First(x => x.Rank == cardRanks.Last());
                return true;
            }

            if ( cardRankTwo )
            {
                FourCardsRanks = cardRanks.Last();
                FourOfAKind = Cards.Where(x => x.Rank == cardRanks.Last()); // todo testing
                OtherCard = Cards.First(x => x.Rank == cardRanks.First());
                return true;
            }

            return false;
        }

        [NotNull]
        public ICard OtherCard { get; private set; }

        public CardRank FourCardsRanks { get; private set; }
        public IEnumerable <ICard> FourOfAKind { get; set; }

        private bool AreThereFourCardsWithSameRank(
            CardRank cardRank,
            [NotNull] IEnumerable <CardRank> cardRanks)
        {
            IEnumerable <CardRank> countSecond = cardRanks.Where(x => x == cardRank);

            if ( countSecond.Count() == 4 )
            {
                return true;
            }

            return false;
        }
    }
}
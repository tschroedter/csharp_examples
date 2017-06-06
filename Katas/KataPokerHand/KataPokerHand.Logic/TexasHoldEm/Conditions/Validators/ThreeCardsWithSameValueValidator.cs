using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions.Validators
{
    public class ThreeCardsWithSameValueValidator
        : IThreeCardsWithSameValueValidator // todo rename to match condition
    {
        public ThreeCardsWithSameValueValidator()
        {
            Cards = new ICard[0];
            Rank = CardRank.Unknown;
            ThreeOfAKind = new ICard[0];
        }

        public IEnumerable <ICard> Cards { get; set; }

        public bool IsValid()
        {
            IEnumerable <CardRank> values = Cards.Select(x => x.Rank);

            IEnumerable <CardRank> cardRanks = values as CardRank[] ?? values.ToArray();
            IEnumerable <IGrouping <CardRank, CardRank>> grouped = cardRanks.GroupBy(x => x).ToArray();

            if ( grouped.Count() < 2 )
            {
                return false;
            }

            foreach ( IGrouping <CardRank, CardRank> grouping in grouped )
            {
                int count = grouping.Count();

                if ( count != 3 )
                {
                    continue;
                }

                CardRank cardRank = grouping.Key;

                Rank = cardRank;
                ThreeOfAKind = Cards.Where(x => x.Rank == cardRank);

                return true;
            }

            return false;
        }

        public CardRank Rank { get; private set; }

        public IEnumerable <ICard> ThreeOfAKind { get; set; }
    }
}
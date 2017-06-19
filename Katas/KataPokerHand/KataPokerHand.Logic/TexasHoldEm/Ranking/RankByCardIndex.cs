using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class RankByCardIndex
        : IRankByCardIndex
    {
        public bool HasSingleWinnerAtCardIndex(
            int cardIndex,
            IPlayerHandInformation[] infos)
        {
            IOrderedEnumerable<IPlayerHandInformation> threeOfAKind =
                infos.OrderByDescending(x => x.Cards.ElementAt(cardIndex).Rank);

            IGrouping<CardRank, IPlayerHandInformation>[] grouped =
                threeOfAKind.GroupBy(x => x.Cards.ElementAt(cardIndex).Rank).ToArray();

            return grouped.Count() == infos.Length;
        }

        public IEnumerable<IPlayerHandInformation> RankedByCardIndex(
            int cardIndex,
            IPlayerHandInformation[] infos)
        {
            var list = new List<IPlayerHandInformation>();

            IOrderedEnumerable<IPlayerHandInformation> threeOfAKind =
                infos.OrderByDescending(x => x.Cards.ElementAt(cardIndex).Rank);

            IGrouping<CardRank, IPlayerHandInformation>[] grouped =
                threeOfAKind.GroupBy(x => x.Cards.ElementAt(cardIndex).Rank).ToArray();

            list.AddRange(grouped.Count() != infos.Length
                              ? infos
                              : grouped.Select(group => @group.First()));

            return list;
        }
    }
}
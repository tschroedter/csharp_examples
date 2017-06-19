using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class HighCardRanking
        : BaseRanking,
          IHighCardRanking
    {
        public HighCardRanking()
            : base(Status.HighCard)
        {
        }

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            // todo extract to be used in other rankings
            for ( var i = 0 ; i < infos [ 0 ].Cards.Count() ; i++ )
            {
                if ( !HasSingleWinnerAtCardIndex(i,
                                                 infos) )
                {
                    continue;
                }

                Winner = WinnerStatus.SingleWinner;

                m_Ranked.AddRange(RankedByCardIndex(i,
                                                    infos));

                return;
            }

            Winner = WinnerStatus.MultipleWinners;

            m_Ranked.AddRange(infos);
        }

        private bool HasSingleWinnerAtCardIndex(
            int cardIndex,
            [NotNull] IPlayerHandInformation[] infos)
        {
            IOrderedEnumerable <IPlayerHandInformation> threeOfAKind =
                infos.OrderByDescending(x => x.Cards.ElementAt(cardIndex).Rank);

            IGrouping <CardRank, IPlayerHandInformation>[] grouped =
                threeOfAKind.GroupBy(x => x.Cards.ElementAt(cardIndex).Rank).ToArray();

            return grouped.Count() == infos.Length;
        }

        private IEnumerable <IPlayerHandInformation> RankedByCardIndex(
            int cardIndex,
            [NotNull] IPlayerHandInformation[] infos)
        {
            var list = new List <IPlayerHandInformation>();

            IOrderedEnumerable <IPlayerHandInformation> threeOfAKind =
                infos.OrderByDescending(x => x.Cards.ElementAt(cardIndex).Rank);

            IGrouping <CardRank, IPlayerHandInformation>[] grouped =
                threeOfAKind.GroupBy(x => x.Cards.ElementAt(cardIndex).Rank).ToArray();

            if ( grouped.Count() != infos.Length )
            {
                return list; // todo log error
            }

            list.AddRange(grouped.Select(group => group.First()));

            return list;
        }
    }
}
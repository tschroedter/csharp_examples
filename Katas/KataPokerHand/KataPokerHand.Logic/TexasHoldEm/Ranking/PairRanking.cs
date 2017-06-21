using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class PairRanking
        : IPairRanking
    {
        private readonly List <IPlayerHandInformation> m_Ranked = new List <IPlayerHandInformation>();

        public void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            // todo check if we can use func to select card here
            IOrderedEnumerable <IPlayerHandInformation> pair =
                infos.OrderByDescending(x => x.PairOfCards
                                              .First()
                                              .Rank);

            IGrouping <CardRank, IPlayerHandInformation>[] grouped =
                pair.GroupBy(x => x.PairOfCards
                                   .First()
                                   .Rank)
                    .ToArray();

            m_Ranked.AddRange(grouped.SelectMany(x => x));

            Winner = grouped.Count() == infos.Length
                         ? WinnerStatus.SingleWinner
                         : WinnerStatus.MultipleWinners;
        }

        public WinnerStatus Winner { get; private set; }
        public IEnumerable <IPlayerHandInformation> Ranked => m_Ranked;
    }
}
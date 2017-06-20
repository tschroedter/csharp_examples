using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class FlushRanking
        : BaseRanking,
          IFlushRanking
    {
        public FlushRanking()
            : base(Status.Flush)
        {
        }

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            IOrderedEnumerable<IPlayerHandInformation> threeOfAKind =
                infos.OrderByDescending(x => x.HighestCard.Rank);

            IGrouping<CardRank, IPlayerHandInformation>[] grouped =
                threeOfAKind.GroupBy(x => x.HighestCard.Rank).ToArray();

            m_Ranked.AddRange(grouped.SelectMany(x => x));

            Winner = grouped.Count() == infos.Length
                         ? WinnerStatus.SingleWinner
                         : WinnerStatus.MultipleWinners;
        }
    }
}
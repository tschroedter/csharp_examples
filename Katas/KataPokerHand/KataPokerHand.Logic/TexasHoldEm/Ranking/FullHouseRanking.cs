using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class FullHouseRanking
        : BaseRanking,
          IFullHouseRanking
    {
        public FullHouseRanking()
            : base(Status.FullHouse)
        {
        }

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            IOrderedEnumerable <IPlayerHandInformation> threeOfAKind =
                infos.OrderByDescending(x => x.ThreeOfAKind.First().Rank);

            IGrouping <CardRank, IPlayerHandInformation>[] grouped =
                threeOfAKind.GroupBy(x => x.ThreeOfAKind.First().Rank).ToArray();

            m_Ranked.AddRange(grouped.SelectMany(x => x));

            Winner = grouped.Count() == infos.Length
                         ? WinnerStatus.SingleWinner
                         : WinnerStatus.MultipleWinners;
        }
    }
}
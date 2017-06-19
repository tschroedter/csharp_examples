using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class FullHouseRanking
        : IFullHouseRanking
    {
        [NotNull]
        private readonly List <IPlayerHandInformation> m_Ranked = new List <IPlayerHandInformation>();

        public bool CanApply(Status status)
        {
            return Status.FullHouse == status;
        }

        public void Apply(IPlayerHandInformation[] infos)
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

        public IEnumerable <IPlayerHandInformation> Ranked => m_Ranked;
        public WinnerStatus Winner { get; private set; }
    }
}
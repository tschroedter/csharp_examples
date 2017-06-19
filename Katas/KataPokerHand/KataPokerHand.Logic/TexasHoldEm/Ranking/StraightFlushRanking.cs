using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class StraightFlushRanking
        : IStraightFlushRanking
    {
        [NotNull]
        private readonly List <IPlayerHandInformation> m_Ranked = new List <IPlayerHandInformation>();

        public bool CanApply(Status status)
        {
            return Status.StraightFlush == status;
        }

        public void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            IOrderedEnumerable <IPlayerHandInformation> sorted = infos.OrderByDescending(x => x.HighestCard.Rank);

            m_Ranked.AddRange(sorted);

            IEnumerable <IGrouping <CardRank, IPlayerHandInformation>> grouped = infos.GroupBy(x => x.HighestCard.Rank);

            Winner = grouped.Count() == 1
                         ? WinnerStatus.MultipleWinners
                         : WinnerStatus.SingleWinner;
        }

        public IEnumerable <IPlayerHandInformation> Ranked => m_Ranked;

        public WinnerStatus Winner { get; private set; } = WinnerStatus.Unknown;
    }
}
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public abstract class SingleHighestCardRanking
        : ISameStatusRanking
    {
        protected SingleHighestCardRanking(
            Status status)
        {
            m_Status = status;
        }

        [NotNull]
        private readonly List <IPlayerHandInformation> m_Ranked = new List <IPlayerHandInformation>();

        private readonly Status m_Status;

        public bool CanApply(Status status)
        {
            return m_Status == status;
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
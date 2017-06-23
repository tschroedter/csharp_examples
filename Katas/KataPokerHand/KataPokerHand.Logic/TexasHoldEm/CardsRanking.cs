using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class CardsRanking
        : ICardsRanking
    {
        public CardsRanking(
            [NotNull] IPlayerInformationGroupedByStatus grouped,
            [NotNull] ISameStatusRankingContainer rankings)
        {
            m_Grouped = grouped;
            m_Rankings = rankings;

            Winner = WinnerStatus.Unknown;
            WinnerInformation = new PlayerHandInformation();
        }

        [NotNull]
        private readonly IPlayerInformationGroupedByStatus m_Grouped;

        private readonly ISameStatusRankingContainer m_Rankings;

        public void Apply(IEnumerable <IPlayerHandInformation> infos)
        {
            Winner = WinnerStatus.Unknown;
            WinnerInformation = new PlayerHandInformation();

            m_Grouped.Group(infos);

            foreach ( Status status in m_Grouped.Keys )
            {
                IEnumerable <IPlayerHandInformation> statusInfos = m_Grouped [ status ].ToArray();

                if ( statusInfos.Count() == 1 ) // todo testing this if
                {
                    Winner = WinnerStatus.SingleWinner;
                    WinnerInformation = statusInfos.First();
                    return;
                }

                m_Rankings.Apply(statusInfos.ToArray());

                if ( WinnerStatus.SingleWinner != m_Rankings.Winner )
                {
                    continue;
                }

                Winner = m_Rankings.Winner;
                WinnerInformation = m_Rankings.Ranked.First();
            }
        }

        public IPlayerHandInformation WinnerInformation { get; set; }

        public WinnerStatus Winner { get; set; }
    }
}
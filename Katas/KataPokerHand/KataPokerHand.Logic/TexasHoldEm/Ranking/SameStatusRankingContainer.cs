using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class SameStatusRankingContainer // todo testing
        : ISameStatusRankingContainer
    {
        public SameStatusRankingContainer(
            [NotNull] IEnumerable <ISameStatusRanking> rankings)
        {
            m_Rankings = rankings;
        }

        [NotNull]
        private readonly List <IPlayerHandInformation> m_Ranked = new List <IPlayerHandInformation>();

        [NotNull]
        private readonly IEnumerable <ISameStatusRanking> m_Rankings;

        public bool CanApply(Status status)
        {
            return m_Rankings.Any(x => x.CanApply(status));
        }

        public void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();
            Winner = WinnerStatus.Unknown;

            Status status = infos.First().Status;

            foreach ( ISameStatusRanking ranking in m_Rankings )
            {
                if ( !ranking.CanApply(status) )
                {
                    continue;
                }

                ranking.Apply(infos);

                Winner = ranking.Winner;
                m_Ranked.AddRange(ranking.Ranked);

                break;
            }
        }

        public IEnumerable <IPlayerHandInformation> Ranked => m_Ranked;
        public WinnerStatus Winner { get; private set; }
    }
}
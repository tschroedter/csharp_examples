using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public abstract class BaseRanking
        : ISameStatusRanking
    {
        protected BaseRanking(Status status)
        {
            m_Status = status;
        }

        [NotNull]
        protected readonly List <IPlayerHandInformation> m_Ranked = new List <IPlayerHandInformation>();

        protected readonly Status m_Status;

        public bool CanApply(Status status)
        {
            return m_Status == status;
        }

        public abstract void Apply(IPlayerHandInformation[] infos);

        public IEnumerable <IPlayerHandInformation> Ranked => m_Ranked;
        public WinnerStatus Winner { get; protected set; }
    }
}
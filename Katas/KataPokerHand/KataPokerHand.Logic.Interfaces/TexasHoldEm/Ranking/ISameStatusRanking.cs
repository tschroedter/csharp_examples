using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking
{
    public interface ISameStatusRanking
    {
        bool CanApply(Status status);
        void Apply([NotNull] IPlayerHandInformation[] infos);
        [NotNull]
        IEnumerable <IPlayerHandInformation> Ranked { get; }

        WinnerStatus Winner { get; }
    }
}
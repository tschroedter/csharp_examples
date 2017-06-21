using System.Collections.Generic;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking
{
    public interface IPairRanking
    {
        void Apply(IPlayerHandInformation[] infos);
        WinnerStatus Winner { get; }
        IEnumerable<IPlayerHandInformation> Ranked { get; }
    }
}
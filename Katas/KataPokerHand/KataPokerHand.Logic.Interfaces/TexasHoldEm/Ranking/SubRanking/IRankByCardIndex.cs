using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking.SubRanking
{
    public interface IRankByCardIndex
    {
        bool HasSingleWinnerAtCardIndex(
            int cardIndex,
            [NotNull] IPlayerHandInformation[] infos);

        IEnumerable<IPlayerHandInformation> RankedByCardIndex(
            int cardIndex,
            [NotNull] IPlayerHandInformation[] infos);
    }
}
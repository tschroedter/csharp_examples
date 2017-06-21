using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface ICardsRanking
    {
        void Apply([NotNull] IEnumerable <IPlayerHandInformation> infos);
        WinnerStatus Winner { get; }
        [NotNull]
        IPlayerHandInformation WinnerInformation { get; }
    }
}
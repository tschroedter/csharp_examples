using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking
{
    public interface IRankByHighCards
    {
        void Rank(Status status,
                  [NotNull] IPlayerHandInformation[] infos);

        [NotNull]
        IEnumerable <IPlayerHandInformation> Ranked { get; }
    }
}
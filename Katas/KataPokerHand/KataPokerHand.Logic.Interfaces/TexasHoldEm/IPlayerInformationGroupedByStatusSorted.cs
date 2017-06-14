using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface IPlayerInformationGroupedByStatusSorted
    {
        [NotNull]
        IEnumerable <Status> GetAllStatus();

        [NotNull]
        IEnumerable <IPlayerHandInformation> GetPlayerHandInformations(
            Status key);

        void GroupBy();
    }
}
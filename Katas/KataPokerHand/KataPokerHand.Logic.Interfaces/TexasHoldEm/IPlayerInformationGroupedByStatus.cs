using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface IPlayerInformationGroupedByStatus
    {
        [NotNull]
        IEnumerable <Status> Keys();

        [NotNull]
        IEnumerable <IPlayerHandInformation> Values(
            Status key);

        void Group([NotNull] IEnumerable<IPlayerHandInformation> informations);

        [NotNull]
        IEnumerable <IPlayerHandInformation> All();
    }
}
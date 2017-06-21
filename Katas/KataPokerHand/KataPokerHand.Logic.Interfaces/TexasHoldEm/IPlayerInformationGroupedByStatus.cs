using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface IPlayerInformationGroupedByStatus
    {
        [NotNull]
        IEnumerable <Status> Keys { get; }

        [NotNull]
        IEnumerable <IPlayerHandInformation> this[Status status] { get; }

        [NotNull]
        IEnumerable <IPlayerHandInformation> All();

        void Group([NotNull] IEnumerable <IPlayerHandInformation> informations);
    }
}
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class PlayerInformationGroupedByStatusSorted
        : IPlayerInformationGroupedByStatusSorted
    {
        public PlayerInformationGroupedByStatusSorted(
            [NotNull] IEnumerable <IPlayerHandInformation> informations)
        {
            m_Informations = informations;
        }

        [NotNull]
        private readonly IEnumerable <IPlayerHandInformation> m_Informations;

        [NotNull]
        private IEnumerable <IGrouping <Status, IPlayerHandInformation>> m_Grouped =
            new IGrouping <Status, IPlayerHandInformation>[0];

        public IEnumerable <Status> GetAllStatus()
        {
            return m_Grouped.Select(x => x.Key).OrderBy(x => x);
        }

        public IEnumerable <IPlayerHandInformation> GetPlayerHandInformations(
            Status key)
        {
            return m_Grouped.Where(x => x.Key == key).SelectMany(group => group);
        }

        public void GroupBy()
        {
            m_Grouped = m_Informations.GroupBy(x => x.Status);
        }
    }
}
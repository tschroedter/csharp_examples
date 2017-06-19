using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class PlayerInformationGroupedByStatus
        : IPlayerInformationGroupedByStatus
    {
        [NotNull]
        private readonly Dictionary <Status, IEnumerable <IPlayerHandInformation>> m_Dictionary =
            new Dictionary <Status, IEnumerable <IPlayerHandInformation>>();

        public IEnumerable <Status> Keys()
        {
            return m_Dictionary.Keys;
        }

        public IEnumerable <IPlayerHandInformation> Values(
            Status key)
        {
            return !m_Dictionary.ContainsKey(key)
                       ? new IPlayerHandInformation[0]
                       : m_Dictionary [ key ];
        }

        public void Group(
            IEnumerable <IPlayerHandInformation> informations)
        {
            IGrouping <Status, IPlayerHandInformation>[] grouped = informations.GroupBy(x => x.Status).ToArray();
            IOrderedEnumerable <Status> allStatus = grouped.Select(x => x.Key).OrderBy(x => x);

            m_Dictionary.Clear();

            foreach ( Status status in allStatus )
            {
                IEnumerable <IPlayerHandInformation> infos =
                    grouped.Where(x => x.Key == status).SelectMany(group => group);

                m_Dictionary.Add(status,
                                 infos);
            }
        }
    }
}
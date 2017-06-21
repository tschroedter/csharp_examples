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

        public IEnumerable <Status> Keys => m_Dictionary.Keys;

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

        public IEnumerable <IPlayerHandInformation> All()
        {
            var list = new List <IPlayerHandInformation>();

            foreach ( Status key in m_Dictionary.Keys )
            {
                list.AddRange(m_Dictionary [ key ]);
            }

            return list;
        }

        public IEnumerable <IPlayerHandInformation> this[Status status]
        {
            get
            {
                IEnumerable <IPlayerHandInformation> infos;

                return m_Dictionary.TryGetValue(status,
                                                out infos)
                           ? infos
                           : new IPlayerHandInformation[0];
            }
        }
    }
}
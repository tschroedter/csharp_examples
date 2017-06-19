using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public abstract class SingleHighestCardRanking
        : BaseRanking
    {
        protected SingleHighestCardRanking(Status status)
            : base(status)
        {
        }

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            IOrderedEnumerable <IPlayerHandInformation> sorted = infos.OrderByDescending(x => x.HighestCard.Rank);

            m_Ranked.AddRange(sorted);

            IEnumerable <IGrouping <CardRank, IPlayerHandInformation>> grouped = infos.GroupBy(x => x.HighestCard.Rank);

            Winner = grouped.Count() == 1
                         ? WinnerStatus.MultipleWinners
                         : WinnerStatus.SingleWinner;
        }
    }
}
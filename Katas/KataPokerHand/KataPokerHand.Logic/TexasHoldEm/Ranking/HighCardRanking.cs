using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking.SubRanking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class HighCardRanking
        : BaseRanking,
          IHighCardRanking
    {
        public HighCardRanking(
            [NotNull] IRankByCardIndex rankByCardIndex)
            : base(Status.HighCard)
        {
            m_RankByCardIndex = rankByCardIndex;
        }

        [NotNull]
        private readonly IRankByCardIndex m_RankByCardIndex;

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            for ( var i = 0 ; i < infos [ 0 ].Cards.Count() ; i++ )
            {
                if ( !m_RankByCardIndex.HasSingleWinnerAtCardIndex(i,
                                                                   infos) )
                {
                    continue;
                }

                Winner = WinnerStatus.SingleWinner;

                m_Ranked.AddRange(m_RankByCardIndex.RankedByCardIndex(i,
                                                                      infos));

                return;
            }

            Winner = WinnerStatus.MultipleWinners;

            m_Ranked.AddRange(infos);
        }
    }
}
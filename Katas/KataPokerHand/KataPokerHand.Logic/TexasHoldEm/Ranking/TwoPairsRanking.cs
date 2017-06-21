using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class TwoPairsRanking
        : BaseRanking,
          ITwoPairsRanking
    {
        public TwoPairsRanking(
            [NotNull] IFirstPairRanking firstPairRanking,
            [NotNull] ISecondPairRanking secondPairRanking,
            [NotNull] IHighCardRanking highCardRanking)
            : base(Status.TwoPairs)
        {
            m_FirstPairRanking = firstPairRanking;
            m_SecondPairRanking = secondPairRanking;
            m_HighCardRanking = highCardRanking;
        }

        private readonly IFirstPairRanking m_FirstPairRanking;
        private readonly IHighCardRanking m_HighCardRanking;
        private readonly ISecondPairRanking m_SecondPairRanking;

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            m_FirstPairRanking.Apply(infos);

            if ( m_FirstPairRanking.Winner == WinnerStatus.SingleWinner )
            {
                Winner = m_FirstPairRanking.Winner;
                m_Ranked.AddRange(m_FirstPairRanking.Ranked);
                return;
            }

            m_SecondPairRanking.Apply(infos);

            if ( m_SecondPairRanking.Winner == WinnerStatus.SingleWinner )
            {
                Winner = m_SecondPairRanking.Winner;
                m_Ranked.AddRange(m_SecondPairRanking.Ranked);
                return;
            }

            m_HighCardRanking.Apply(infos);
            Winner = m_HighCardRanking.Winner;
            m_Ranked.AddRange(m_HighCardRanking.Ranked);
        }
    }
}
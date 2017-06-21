using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class PairOfCardsOfCardsRanking
        : BaseRanking,
          IPairOfCardsRanking
    {
        public PairOfCardsOfCardsRanking(
            [NotNull] IPairRanking pairRanking,
            [NotNull] IHighCardRanking highCardRanking)
            : base(Status.TwoPairs)
        {
            m_PairRanking = pairRanking;
            m_HighCardRanking = highCardRanking;
        }

        private readonly IHighCardRanking m_HighCardRanking;

        private readonly IPairRanking m_PairRanking;

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            m_PairRanking.Apply(infos);

            if ( m_PairRanking.Winner == WinnerStatus.SingleWinner )
            {
                Winner = m_PairRanking.Winner;
                m_Ranked.AddRange(m_PairRanking.Ranked);
                return;
            }

            m_HighCardRanking.Apply(infos);
            Winner = m_HighCardRanking.Winner;
            m_Ranked.AddRange(m_HighCardRanking.Ranked);
        }
    }
}
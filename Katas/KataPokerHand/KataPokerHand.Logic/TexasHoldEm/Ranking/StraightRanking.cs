using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class StraightRanking
        : BaseRanking,
          IStraightRanking
    {
        private readonly IHighCardRanking m_HighCardRanking;

        public StraightRanking(
            [NotNull] IHighCardRanking highCardRanking)
            : base(Status.Straight)
        {
            m_HighCardRanking = highCardRanking;
        }

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            m_HighCardRanking.Apply(infos);

            m_Ranked.AddRange(m_HighCardRanking.Ranked);

            Winner = m_HighCardRanking.Winner;
        }
    }
}
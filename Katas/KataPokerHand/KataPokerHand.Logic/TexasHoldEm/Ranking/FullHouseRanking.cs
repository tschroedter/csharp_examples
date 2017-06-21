using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    public class FullHouseRanking
        : BaseRanking,
          IFullHouseRanking
    {
        [NotNull]
        private readonly IThreeOfAKindRanking m_Ranking;

        public FullHouseRanking(
            [NotNull] IThreeOfAKindRanking ranking)
            : base(Status.FullHouse)
        {
            m_Ranking = ranking;
        }

        public override void Apply(IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            m_Ranking.Apply(infos);

            m_Ranked.AddRange(m_Ranking.Ranked);

            Winner = m_Ranking.Winner;
        }
    }
}
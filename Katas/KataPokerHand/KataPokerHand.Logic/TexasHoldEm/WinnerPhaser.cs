using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class WinnerPhaser
        : IWinnerPhaser
    {
        [NotNull]
        private readonly ICardsRankEngine m_PhaseOne;

        [NotNull]
        private readonly IPlayerInformationGroupedByStatusSorted m_PhaseTwo;

        // todo testing
        // todo continue here
        public WinnerPhaser(
            [NotNull] ICardsRankEngine phaseOne,
            [NotNull] IPlayerInformationGroupedByStatusSorted phaseTwo)
        {
            m_PhaseOne = phaseOne;
            m_PhaseTwo = phaseTwo;
        }
    }

    public interface IWinnerPhaser
    {
    }
}
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    [ExcludeFromCodeCoverage]
    public class StraightFlushRanking
        : SingleHighestCardRanking
        , IStraightFlushRanking
    {
        public StraightFlushRanking()
            : base(Status.StraightFlush)
        {
        }
    }
}
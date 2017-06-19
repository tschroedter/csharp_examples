using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Ranking
{
    [ExcludeFromCodeCoverage]
    public class FourOfAKindRanking
        : SingleHighestCardRanking
          , IFourOfAKindRanking
    {
        public FourOfAKindRanking()
            : base(Status.FourOfAKind)
        {
        }
    }
}
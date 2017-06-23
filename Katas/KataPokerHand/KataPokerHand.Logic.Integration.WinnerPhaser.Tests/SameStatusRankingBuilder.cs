using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using KataPokerHand.Logic.TexasHoldEm.Ranking.SubRanking;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests
{
    [ExcludeFromCodeCoverage]
    public class SameStatusRankingBuilder
    {
        public SameStatusRankingBuilder()
        {
            Rankings = new ISameStatusRanking[]
                       {
                           new FlushRanking(),
                           new FourOfAKindRanking(),
                           new FullHouseRanking(new ThreeOfAKindRanking()),
                           new HighCardRanking(new RankByCardIndex()),
                           new PairOfCardsOfCardsRanking(new PairRanking(),
                                                         new HighCardRanking(new RankByCardIndex())),
                           // todo check this class new SingleHighestCardRanking(),
                           new StraightFlushRanking(),
                           new StraightRanking(new HighCardRanking(new RankByCardIndex())),
                           new ThreeOfAKindRanking(),
                           new TwoPairsRanking(new FirstPairRanking(),
                                               new SecondPairRanking(),
                                               new HighCardRanking(new RankByCardIndex()))
                       };
        }

        public IEnumerable <ISameStatusRanking> Rankings { get; }
    }
}
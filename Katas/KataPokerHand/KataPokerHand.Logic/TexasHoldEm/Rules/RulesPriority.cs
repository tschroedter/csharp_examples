namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public enum RulesPriority
    {
        Unknown,
        NumberOfCardsIncorrect,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPairs,
        OnePairs,
        HighCard
    }
}
﻿namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules
{
    public enum Status
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
        OnePair,
        HighCard
    }
}
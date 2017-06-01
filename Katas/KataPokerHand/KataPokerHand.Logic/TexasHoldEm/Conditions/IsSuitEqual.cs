﻿using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsSuitEqual
        : BaseCardCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return CardOne.Suit == CardTwo.Suit;
        }
    }
}
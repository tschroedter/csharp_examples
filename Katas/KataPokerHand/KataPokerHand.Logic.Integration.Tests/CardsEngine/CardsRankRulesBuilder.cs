using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using KataPokerHand.Logic.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using Rules.Logic.Interfaces.Rules;

namespace KataPokerHand.Logic.Integration.Tests.CardsEngine
{
    [ExcludeFromCodeCoverage]
    public class CardsRankRulesBuilder
    {
        public IEnumerable <IRule <IPlayerHandInformation>> Rules =
            new IRule <IPlayerHandInformation>[]
            {
                new IsStraightFlushRule(new IsSameSuitAllConditionCards(),
                                        new IsStraightCondition()),
                new IsFourOfAKindRule(new IsFourCardsSameValueCondition(new FourCardsWithSameValueValidator()),
                                      new FourCardsWithSameValueValidator()),
                new IsFullHouseRule(new IsFullHouseCondition(new FullHouseValidator()),
                                    new FullHouseValidator()),
                new IsFlushRule(new IsSameSuitAllConditionCards()),
                new IsStraightRule(new IsStraightCondition()),
                new IsThreeOfAKindRule(new IsThreeOfAKindCondition(new ThreeCardsWithSameValueValidator()),
                                       new ThreeCardsWithSameValueValidator()),
                new IsTwoPairsRule(new IsTwoPairsCondition(new TwoPairsValidator()),
                                   new TwoPairsValidator()),
                new IsOnePairRule(new IsOnePairCondition(new OnePairValidator()),
                                  new OnePairValidator()),
                new IsHighCardRule(new IsAlwaysTrue())
            };
    }
}
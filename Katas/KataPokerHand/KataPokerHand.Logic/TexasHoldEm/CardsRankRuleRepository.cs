using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic;
using Rules.Logic.Interfaces.Rules;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class CardsRankRuleRepository
        : RuleRepository <IPlayerHandInformation>
          , ICardsRankRuleRepository
    {
        public CardsRankRuleRepository()
        {
        }

        public CardsRankRuleRepository(
            [NotNull] IEnumerable <IRule <IPlayerHandInformation>> rules)
            : base(rules)
        {
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic;
using Rules.Logic.Interfaces.Rules;

namespace KataPokerHand.Logic.TexasHoldEm
{
    [ExcludeFromCodeCoverage]
    public class CardsRankRuleRepository
        : RuleRepository <IPlayerHandInformation>,
          ICardsRankRuleRepository
    {
        public CardsRankRuleRepository(
            [NotNull] IEnumerable <IRule <IPlayerHandInformation>> rules)
            : base(rules)
        {
        }
    }
}
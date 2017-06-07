using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class CardsRankEngine
        : Engine <IPlayerHandInformation>
        , ICardsRankEngine
    {
        public CardsRankEngine(
            [NotNull] ICardsRankRuleRepository repository)
            : base(repository)
        {
        }
    }
}

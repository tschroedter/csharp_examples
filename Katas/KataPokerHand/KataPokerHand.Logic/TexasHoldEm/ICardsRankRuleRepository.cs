using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public interface ICardsRankRuleRepository
        : IRuleRepository <IPlayerHandInformation>
    {
    }
}
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic.Interfaces;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm
{
    public interface ICardsRankRulesRepository
        : IRuleRepository <IPlayerHandInformation>
    {
    }
}
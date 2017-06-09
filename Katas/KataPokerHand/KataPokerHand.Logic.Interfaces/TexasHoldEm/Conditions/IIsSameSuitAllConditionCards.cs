using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsSameSuitAllConditionCards
        : ICondition
    {
        ICard[] Cards { set; }
    }
}
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules
{
    public interface IIsSameSuitAllCards
        : ICondition
    {
        ICard[] Cards { set; }
    }
}
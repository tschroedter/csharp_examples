using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules
{
    public interface IIsNumberOfCardsValid
        : ICondition
    {
        ICard[] Cards { set; }
        int NumberOfCardsRequired { get; set; }
        int NumberOfCards { get; }
        bool IsSatisfied();
    }
}
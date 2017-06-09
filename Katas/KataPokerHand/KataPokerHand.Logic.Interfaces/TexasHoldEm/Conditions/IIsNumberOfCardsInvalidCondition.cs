using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsNumberOfCardsInvalidCondition
        : ICondition
    {
        ICard[] Cards { set; }
        int NumberOfCardsRequired { get; set; }
        int NumberOfCards { get; }
    }
}
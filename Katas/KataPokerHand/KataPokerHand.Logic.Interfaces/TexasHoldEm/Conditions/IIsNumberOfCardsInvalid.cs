using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsNumberOfCardsInvalid
        : ICondition
    {
        ICard[] Cards { set; }
        int NumberOfCardsRequired { get; set; }
        int NumberOfCards { get; }
    }
}
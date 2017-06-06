using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public interface IIsTwoPairs
        : ICondition
    {
        ICard[] Cards { get; set; }
    }
}
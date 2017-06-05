using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IIsFourCardsSameValue
        : ICondition
    {
        [NotNull]
        ICard[] Cards { set; }
    }
}
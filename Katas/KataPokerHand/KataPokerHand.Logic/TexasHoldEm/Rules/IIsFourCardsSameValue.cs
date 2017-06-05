using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public interface IIsFourCardsSameValue
        : ICondition
    {
        [NotNull]
        ICard[] Cards { set; }
    }
}
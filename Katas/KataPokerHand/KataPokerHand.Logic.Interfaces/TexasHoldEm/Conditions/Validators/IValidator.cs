using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators
{
    public interface IValidator
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }

        bool IsValid();
    }
}
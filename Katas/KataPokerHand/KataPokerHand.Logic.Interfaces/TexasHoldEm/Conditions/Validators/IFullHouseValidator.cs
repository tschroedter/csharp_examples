using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators
{
    public interface IFullHouseValidator
        : IValidator
    {
        int NumberOfCardsWithSameValue { get; }

        [NotNull]
        IEnumerable <ICard> TwoOfAKind { get; set; }

        [NotNull]
        IEnumerable <ICard> ThreeOfAKind { get; set; }
    }
}
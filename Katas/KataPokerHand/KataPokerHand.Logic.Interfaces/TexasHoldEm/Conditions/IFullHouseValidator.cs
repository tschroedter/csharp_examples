using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IFullHouseValidator
    {
        int NumberOfCardsWithSameValue { get; }

        [NotNull]
        IEnumerable <ICard> Cards { get; set; }

        [NotNull]
        IEnumerable <ICard> TwoOfAKind { get; set; }

        [NotNull]
        IEnumerable <ICard> ThreeOfAKind { get; set; }

        bool IsValid();
    }
}
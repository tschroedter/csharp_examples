using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IThreeCardsWithSameValueValidator
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }

        [NotNull]
        IEnumerable <ICard> ThreeOfAKind { get; }

        CardRank Rank { get; }

        bool IsValid();
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators
{
    public interface IThreeCardsWithSameValueValidator
        : IValidator
    {
        [NotNull]
        IEnumerable <ICard> ThreeOfAKind { get; }

        CardRank Rank { get; }

        [NotNull]
        IEnumerable <ICard> OtherCards { get; }

        [NotNull]
        ICard HighestCard { get; }
    }
}
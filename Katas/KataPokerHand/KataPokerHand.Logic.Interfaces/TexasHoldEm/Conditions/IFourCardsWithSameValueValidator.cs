using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface IFourCardsWithSameValueValidator
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }

        [NotNull]
        ICard OtherCard { get; }

        CardRank FourCardsRanks { get; }

        [NotNull]
        IEnumerable <ICard> FourOfAKind { get; set; }

        bool IsValid();
    }
}
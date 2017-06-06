using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators
{
    public interface IFourCardsWithSameValueValidator
        : IValidator
    {
        [NotNull]
        ICard OtherCard { get; }

        CardRank FourCardsRanks { get; }

        [NotNull]
        IEnumerable <ICard> FourOfAKind { get; set; }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions
{
    public interface ITwoPairsValidator
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }

        [NotNull]
        IEnumerable <ICard> FirstPairOfCards { get; set; }

        [NotNull]
        IEnumerable <ICard> SecondPairOfCards { get; set; }

        bool IsValid();
    }
}
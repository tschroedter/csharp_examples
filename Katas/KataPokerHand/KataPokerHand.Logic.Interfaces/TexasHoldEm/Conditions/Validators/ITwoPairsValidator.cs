using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators
{
    public interface ITwoPairsValidator
        : IValidator
    {
        [NotNull]
        IEnumerable <ICard> FirstPairOfCards { get; set; }

        [NotNull]
        IEnumerable <ICard> SecondPairOfCards { get; set; }

        [NotNull]
        ICard HighestCard { get; set; }
    }
}
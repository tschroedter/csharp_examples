using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions.Validators
{
    public interface IPairsValidator
        : IValidator
    {
        [NotNull]
        IEnumerable <ICard> PairOfCards { get; set; }
        [NotNull]
        IEnumerable <ICard> OtherCards { get; set; }
    }
}
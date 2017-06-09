using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators
{
    public interface IOnePairValidator
        : IValidator
    {
        [NotNull]
        IEnumerable <ICard> PairOfCards { get; set; }

        [NotNull]
        IEnumerable <ICard> OtherCards { get; set; }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.Suits;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules
{
    public interface IPlayerHandInformation
    {
        [NotNull]
        IEnumerable <ICard> Cards { get; set; }

        Status Status { get; set; }

        [NotNull]
        ISuit Suit { get; set; }

        [NotNull]
        ICard HighestCard { get; set; }

        CardRank Rank { get; set; }

        [NotNull]
        IEnumerable <ICard> TwoOfAKind { get; set; }

        [NotNull]
        IEnumerable <ICard> ThreeOfAKind { get; set; }

        [NotNull]
        IEnumerable <ICard> FourOfAKind { get; set; }

        [NotNull]
        IEnumerable <ICard> FirstPairOfCards { get; set; }

        [NotNull]
        IEnumerable <ICard> SecondPairOfCards { get; set; }

        [NotNull]
        IEnumerable <ICard> PairOfCards { get; set; }

        [NotNull]
        IEnumerable <ICard> OtherCards { get; set; }
    }
}
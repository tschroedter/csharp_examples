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
        ISuit Suit { get; set; } // todo maybe moved into rules engine 2

        [NotNull]
        ICard HighestCard { get; set; } // todo maybe moved into rules engine 2

        CardRank Rank { get; set; } // todo maybe moved into rules engine 2

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
        IEnumerable <ICard> OtherCards { get; set; }    // todo check if we use it/can use it
    }
}
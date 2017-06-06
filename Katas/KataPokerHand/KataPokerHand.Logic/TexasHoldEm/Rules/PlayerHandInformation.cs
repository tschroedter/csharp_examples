﻿using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.Suits;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class PlayerHandInformation
        : IPlayerHandInformation // todo testing
    {
        public PlayerHandInformation(
            [NotNull] IPlayerHand playerHand)
        {
            PlayerHand = playerHand;
            Status = Status.Unknown;
            Suit = UnknownSuit.Unknown;
            HighestCard = UnknownCard.Unknown;
            TwoOfAKind = new ICard[0];
            ThreeOfAKind = new ICard[0];
            FourOfAKind = new ICard[0];
            FirstPairOfCards = new ICard[0];
            SecondPairOfCards = new ICard[0];
        }

        public IPlayerHand PlayerHand { get; }
        public Status Status { get; set; }
        public ISuit Suit { get; set; }
        public ICard HighestCard { get; set; }
        public CardRank Rank { get; set; }
        public IEnumerable <ICard> TwoOfAKind { get; set; }
        public IEnumerable <ICard> ThreeOfAKind { get; set; }
        public IEnumerable <ICard> FourOfAKind { get; set; }
        public IEnumerable <ICard> FirstPairOfCards { get; set; }
        public IEnumerable <ICard> SecondPairOfCards { get; set; }
    }
}
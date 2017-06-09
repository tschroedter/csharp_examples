using System.Collections.Generic;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.Suits;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class PlayerHandInformation
        : IPlayerHandInformation // todo testing, check set we set OtherCards, reduce properties
    {
        public PlayerHandInformation()
        {
            Cards = new ICard[0];
            Status = Status.Unknown;
            Suit = UnknownSuit.Unknown;
            HighestCard = UnknownCard.Unknown;
            TwoOfAKind = new ICard[0];
            ThreeOfAKind = new ICard[0];
            FourOfAKind = new ICard[0];
            FirstPairOfCards = new ICard[0];
            SecondPairOfCards = new ICard[0];
            PairOfCards = new ICard[0];
            OtherCards = new ICard[0];
        }

        public IEnumerable <ICard> Cards { get; set; }
        public Status Status { get; set; }
        public ISuit Suit { get; set; }
        public ICard HighestCard { get; set; }
        public CardRank Rank { get; set; }
        public IEnumerable <ICard> TwoOfAKind { get; set; }
        public IEnumerable <ICard> ThreeOfAKind { get; set; }
        public IEnumerable <ICard> FourOfAKind { get; set; }
        public IEnumerable <ICard> FirstPairOfCards { get; set; }
        public IEnumerable <ICard> SecondPairOfCards { get; set; }
        public IEnumerable <ICard> PairOfCards { get; set; }
        public IEnumerable <ICard> OtherCards { get; set; }
    }
}
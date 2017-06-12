using System.Collections.Generic;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;

namespace KataPokerHand.Logic.Integration.Tests.CardsRankEngineTests
{
    public sealed class CardsBuilder
    {
        public CardsBuilder()
        {
            Cards = CreateCards();
        }

        public IEnumerable <ICard> Cards { get; }

        private static IEnumerable <ICard> CreateCards()
        {
            var cards = new List <ICard>();

            cards.AddRange(CreateClubs());
            cards.AddRange(CreateHearts());
            cards.AddRange(CreateDiamonds());
            cards.AddRange(CreateSpadess());

            return cards;
        }

        private static ICard[] CreateClubs()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new ThreeOfClubs(),
                       new FourOfClubs(),
                       new FiveOfClubs(),
                       new SixOfClubs(),
                       new SevenOfClubs(),
                       new EightOfClubs(),
                       new NineOfClubs(),
                       new JackOfClubs(),
                       new QueenOfClubs(),
                       new KingOfClubs(),
                       new AceOfClubs()
                   };
        }

        private static IEnumerable <ICard> CreateDiamonds()
        {
            return new ICard[]
                   {
                       new TwoOfDiamonds(),
                       new ThreeOfDiamonds(),
                       new FourOfDiamonds(),
                       new FiveOfDiamonds(),
                       new SixOfDiamonds(),
                       new SevenOfDiamonds(),
                       new EightOfDiamonds(),
                       new NineOfDiamonds(),
                       new JackOfDiamonds(),
                       new QueenOfDiamonds(),
                       new KingOfDiamonds(),
                       new AceOfDiamonds()
                   };
        }

        private static IEnumerable <ICard> CreateHearts()
        {
            return new ICard[]
                   {
                       new TwoOfHearts(),
                       new ThreeOfHearts(),
                       new FourOfHearts(),
                       new FiveOfHearts(),
                       new SixOfHearts(),
                       new SevenOfHearts(),
                       new EightOfHearts(),
                       new NineOfHearts(),
                       new JackOfHearts(),
                       new QueenOfHearts(),
                       new KingOfHearts(),
                       new AceOfHearts()
                   };
        }

        private static IEnumerable <ICard> CreateSpadess()
        {
            return new ICard[]
                   {
                       new TwoOfSpades(),
                       new ThreeOfSpades(),
                       new FourOfSpades(),
                       new FiveOfSpades(),
                       new SixOfSpades(),
                       new SevenOfSpades(),
                       new EightOfSpades(),
                       new NineOfSpades(),
                       new JackOfSpades(),
                       new QueenOfSpades(),
                       new KingOfSpades(),
                       new AceOfSpades()
                   };
        }
    }
}
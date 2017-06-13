using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using TechTalk.SpecFlow;
using static System.Console;

namespace KataPokerHand.Logic.Integration.Tests.CardsRankEngineTests
{
    [Binding]
    public class CardsRankEngineSteps
    {
        public CardsRankEngineSteps()
        {
            m_StringToCardRank = new StringToCardRankFactory();
            m_Cards = new List <ICard>();
            m_Info = new PlayerHandInformation
                     {
                         Cards = m_Cards
                     };
            m_StringToCard = new StringToCardFactory();
            m_StringToCard.Initialize(new CardsBuilder().Cards);

            m_Sut = new CardsRankEngine(new CardsRankRulesRepository(new CardsRankRulesBuilder().Rules));
        }

        private readonly List <ICard> m_Cards;
        private readonly IPlayerHandInformation m_Info;
        private readonly IStringToCardFactory m_StringToCard;
        private readonly IStringToCardRankFactory m_StringToCardRank;
        private readonly CardsRankEngine m_Sut;

        [Given(@"I added a card '(.*)' to player cards")]
        public void GivenIAddedACardToPlayerCards(string cardAsString)
        {
            m_Cards.Add(m_StringToCard.ToCard(cardAsString));
        }

        [Then(@"the Rank should be '(.*)'")]
        public void ThenTheCardRankShouldBe(string cardRankAsString)
        {
            CardRank expected = m_StringToCardRank.ToCardRank(cardRankAsString);

            Assert.AreEqual(expected,
                            m_Info.Rank);
        }

        [Then(@"the FirstPairOfCards should be '(.*)'")]
        public void ThenTheFirstPairOfCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.FirstPairOfCards,
                        cards,
                        "FirstPairOfCards");
        }

        [Then(@"the FourOfAKind should be '(.*)'")]
        public void ThenTheFourOfAKindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.FourOfAKind,
                        cards,
                        "FourOfAKind");
        }

        [Then(@"the HighestCard should be '(.*)'")]
        public void ThenTheHighestCardShouldBe(string cardAsString)
        {
            ICard expected = m_StringToCard.ToCard(cardAsString);

            Assert.AreEqual(expected.ToString(),
                            m_Info.HighestCard.ToString()); // todo implement equals for Cards
        }

        [Then(@"the OtherCards should be '(.*)'")]
        public void ThenTheOtherCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.OtherCards,
                        cards,
                        "OtherCards");
        }

        [Then(@"the PairOfCards should be '(.*)'")]
        public void ThenThePairOfCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.PairOfCards,
                        cards,
                        "PairOfCards");
            ;
        }

        [Then(@"the SecondPairOfCards should be '(.*)'")]
        public void ThenTheSecondPairOfCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.SecondPairOfCards,
                        cards,
                        "SecondPairOfCards");
        }

        [Then(@"the status should be '(.*)'")]
        public void ThenTheStatusShouldBe(string statusAsString)
        {
            var expected = ( Status ) Enum.Parse(typeof( Status ),
                                                 statusAsString);

            Assert.AreEqual(expected,
                            m_Info.Status);
        }

        [Then(@"the ThreeOfAkind should be '(.*)'")]
        public void ThenTheThreeOfAkindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.ThreeOfAKind,
                        cards,
                        "ThreeOfAKind");
        }

        [Then(@"the TwoOfAkind should be '(.*)'")]
        public void ThenTheTwoOfAkindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(m_Info.TwoOfAKind,
                        cards,
                        "TwoOfAKind");
        }

        [When(@"I apply the rules")]
        public void WhenIApplyTheRules()
        {
            m_Sut.ApplyRules(new[]
                             {
                                 m_Info
                             });
        }

        private void AssertCards(
            [NotNull] IEnumerable <ICard> expected,
            [NotNull] IEnumerable <ICard> actual,
            [NotNull] string description)
        {
            IEnumerable <ICard> array = expected as ICard[] ?? expected.ToArray();

            foreach ( ICard card in actual )
            {
                WriteLine("'{0}' should contain expected card: {1}",
                          description,
                          card);

                Assert.True(array.Any(x => x.ToString() == card.ToString())); // todo need equals

                WriteLine("Found card: {0}",
                          card);
            }
        }

        private List <ICard> ConvertCardsStringsToList(string cardsAsString)
        {
            var cards = new List <ICard>();

            string[] cardsAStringArray = cardsAsString.Split(',');

            foreach ( string cardAsString in cardsAStringArray )
            {
                cards.Add(m_StringToCard.ToCard(cardAsString.Trim()));
            }

            return cards;
        }
    }
}
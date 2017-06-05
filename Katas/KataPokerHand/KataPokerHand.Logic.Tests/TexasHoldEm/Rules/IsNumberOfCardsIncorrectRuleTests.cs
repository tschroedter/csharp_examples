using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsNumberOfCardsIncorrectRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Valid = Substitute.For <IIsNumberOfCardsValid>();
            m_Sut = new IsNumberOfCardsIncorrectRule(m_Valid);
        }

        private IPlayerHandInformation m_Info;
        private IsNumberOfCardsIncorrectRule m_Sut;
        private IIsNumberOfCardsValid m_Valid;

        [Test]
        public void Apply_Updates_HighestCard()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(UnknownCard.Unknown,
                            actual.HighestCard);
        }

        [Test]
        public void Apply_Updates_Rank()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(CardRank.Unknown,
                            actual.Rank);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.NumberOfCardsIncorrect,
                            actual.Status);
        }

        [Test]
        public void Apply_Updates_Suit()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(UnknownSuit.Unknown,
                            actual.Suit); 
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.NumberOfCardsIncorrect,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Condition_For_Cards_Empty()
        {
            // Arrange
            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            Assert.AreEqual(1,
                            m_Sut.GetConditions().Count()); // todo maybe there is a better test
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            Assert.AreEqual(1,
                            m_Sut.GetConditions().Count()); // todo maybe there is a better test
        }
    }
}
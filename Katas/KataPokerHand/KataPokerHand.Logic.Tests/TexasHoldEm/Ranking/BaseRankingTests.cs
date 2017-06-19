using System;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Ranking
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class BaseRankingTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new TestBaseRanking();
        }

        private TestBaseRanking m_Sut;

        public class TestBaseRanking
            : BaseRanking
        {
            public TestBaseRanking()
                : base(Status.NumberOfCardsIncorrect)
            {
            }

            public bool WasCalledApply { get; private set; }

            public override void Apply(IPlayerHandInformation[] infos)
            {
                WasCalledApply = true;
            }
        }

        [TestCase(Status.Unknown,
            false)]
        [TestCase(Status.NumberOfCardsIncorrect,
            true)]
        [TestCase(Status.StraightFlush,
            false)]
        [TestCase(Status.FourOfAKind,
            false)]
        [TestCase(Status.FullHouse,
            false)]
        [TestCase(Status.Flush,
            false)]
        [TestCase(Status.Straight,
            false)]
        [TestCase(Status.ThreeOfAKind,
            false)]
        [TestCase(Status.TwoPairs,
            false)]
        [TestCase(Status.OnePair,
            false)]
        [TestCase(Status.HighCard,
            false)]
        public void CanApply_Returns_Expected(
            Status status,
            bool expected)
        {
            // Arrange
            Console.WriteLine("Testing: " + status);

            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.CanApply(status));
        }


        [Test]
        public void Apply_Calls_Apply()
        {
            // Arrange
            // Act
            m_Sut.Apply(new IPlayerHandInformation[0]);

            // Assert
            Assert.True(m_Sut.WasCalledApply);
        }
    }
}
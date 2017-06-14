using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.TexasHoldEm
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PlayerInformationGroupedByStatusSortedTests
    {
        [SetUp]
        public void Setup()
        {
            m_InfoOne = new PlayerHandInformation();
            m_InfoTwo = new PlayerHandInformation();
            m_InfoThree = new PlayerHandInformation();

            m_Infos = new[]
                      {
                          m_InfoOne,
                          m_InfoTwo,
                          m_InfoThree
                      };

            m_Sut = new PlayerInformationGroupedByStatusSorted(m_Infos);
        }

        private PlayerHandInformation m_InfoOne;
        private PlayerHandInformation[] m_Infos;
        private PlayerHandInformation m_InfoThree;
        private PlayerInformationGroupedByStatusSorted m_Sut;
        private PlayerHandInformation m_InfoTwo;

        [Test]
        public void GetPlayerHandInformations_Returns_List()
        {
            // Arrange
            m_InfoOne.Status = Status.StraightFlush;
            m_InfoTwo.Status = Status.StraightFlush;
            m_InfoThree.Status = Status.FourOfAKind;

            // Act
            m_Sut.GroupBy();

            // Assert
            IPlayerHandInformation[] actual = m_Sut.GetPlayerHandInformations(Status.StraightFlush).ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual.Contains(m_InfoOne));
            Assert.True(actual.Contains(m_InfoTwo));
        }

        [Test]
        public void GroupBy_Updates_Keys()
        {
            // Arrange
            m_InfoOne.Status = Status.Flush;
            m_InfoThree.Status = Status.FourOfAKind;

            // Act
            m_Sut.GroupBy();

            // Assert
            Assert.AreEqual(3,
                            m_Sut.GetAllStatus().Count());
        }

        [Test]
        public void Keys_Returns_Keys_Sorted()
        {
            // Arrange
            m_InfoOne.Status = Status.HighCard;
            m_InfoTwo.Status = Status.StraightFlush;
            m_InfoThree.Status = Status.FourOfAKind;

            // Act
            m_Sut.GroupBy();

            // Assert
            Status[] actual = m_Sut.GetAllStatus().ToArray();

            Assert.AreEqual(actual [ 0 ],
                            Status.StraightFlush);
            Assert.AreEqual(actual [ 1 ],
                            Status.FourOfAKind);
            Assert.AreEqual(actual [ 2 ],
                            Status.HighCard);
        }
    }
}
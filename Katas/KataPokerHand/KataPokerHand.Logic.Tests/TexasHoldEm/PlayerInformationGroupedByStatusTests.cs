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
    internal sealed class PlayerInformationGroupedByStatusTests
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

            m_Sut = new PlayerInformationGroupedByStatus();
        }

        private PlayerHandInformation m_InfoOne;
        private PlayerHandInformation[] m_Infos;
        private PlayerHandInformation m_InfoThree;
        private PlayerInformationGroupedByStatus m_Sut;
        private PlayerHandInformation m_InfoTwo;

        [Test]
        public void All_Returns_List()
        {
            // Arrange
            m_InfoOne.Status = Status.FourOfAKind;
            m_InfoTwo.Status = Status.StraightFlush;
            m_InfoThree.Status = Status.StraightFlush;

            // Act
            m_Sut.Group(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut.All().ToArray();

            Assert.AreEqual(3,
                            actual.Length);
            Assert.AreEqual(m_InfoTwo,
                            actual.ElementAt(0));
            Assert.AreEqual(m_InfoThree,
                            actual.ElementAt(1));
            Assert.AreEqual(m_InfoOne,
                            actual.ElementAt(2));
        }

        [Test]
        public void Group_Updates_Keys()
        {
            // Arrange
            m_InfoOne.Status = Status.Flush;
            m_InfoThree.Status = Status.FourOfAKind;

            // Act
            m_Sut.Group(m_Infos);

            // Assert
            Assert.AreEqual(3,
                            m_Sut.Keys.Count());
        }

        [Test]
        public void Indexer_Returns_List_For_Known_Key()
        {
            // Arrange
            m_InfoOne.Status = Status.StraightFlush;
            m_InfoTwo.Status = Status.StraightFlush;
            m_InfoThree.Status = Status.FourOfAKind;

            // Act
            m_Sut.Group(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut [ Status.StraightFlush ].ToArray();

            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual.Contains(m_InfoOne));
            Assert.True(actual.Contains(m_InfoTwo));
        }

        [Test]
        public void Indexer_Returns_List_For_Unknown_Key()
        {
            // Arrange
            // Act
            m_Sut.Group(m_Infos);

            // Assert
            IPlayerHandInformation[] actual = m_Sut [ Status.StraightFlush ].ToArray();

            Assert.AreEqual(0,
                            actual.Length);
        }

        [Test]
        public void Keys_Returns_Keys_Sorted()
        {
            // Arrange
            m_InfoOne.Status = Status.HighCard;
            m_InfoTwo.Status = Status.StraightFlush;
            m_InfoThree.Status = Status.FourOfAKind;

            // Act
            m_Sut.Group(m_Infos);

            // Assert
            Status[] actual = m_Sut.Keys.ToArray();

            Assert.AreEqual(actual [ 0 ],
                            Status.StraightFlush);
            Assert.AreEqual(actual [ 1 ],
                            Status.FourOfAKind);
            Assert.AreEqual(actual [ 2 ],
                            Status.HighCard);
        }
    }
}
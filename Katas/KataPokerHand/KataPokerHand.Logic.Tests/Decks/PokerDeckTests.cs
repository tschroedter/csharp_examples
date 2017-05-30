using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PokerDeckTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new PokerDeck();
        }

        private PokerDeck m_Sut;

        // todo
    }
}
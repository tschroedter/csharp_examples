using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.Suits;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class HeartTests
        : BaseSuitTests <Heart>
    {
        public HeartTests()
            : base("Heart")
        {
        }
    }
}
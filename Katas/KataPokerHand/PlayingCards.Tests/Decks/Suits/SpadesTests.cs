using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Suits;

namespace Playing.Tests.Decks.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SpadesTests
        : BaseSuitTests <Spades>
    {
        public SpadesTests()
            : base("Spades")
        {
        }
    }
}
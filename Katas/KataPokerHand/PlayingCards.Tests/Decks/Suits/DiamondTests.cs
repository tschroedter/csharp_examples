using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Suits;

namespace Playing.Tests.Decks.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class DiamondTests
        : BaseSuitTests <Diamond>
    {
        public DiamondTests()
            : base("Diamond")
        {
        }
    }
}
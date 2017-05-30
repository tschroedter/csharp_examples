using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeTests
        : BaseCardValueTests <Three>
    {
        public ThreeTests()
            : base("3",
                   new[]
                   {
                       3u
                   })
        {
        }
    }
}
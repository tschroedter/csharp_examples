using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeTests
        : BaseCardValueTests <Three>
    {
        public ThreeTests()
            : base('3',
                   "Three",
                   new[]
                   {
                       3u
                   })
        {
        }
    }
}
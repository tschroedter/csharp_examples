using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixTests
        : BaseCardValueTests <Six>
    {
        public SixTests()
            : base('6',
                   "Six",
                   new[]
                   {
                       6u
                   })
        {
        }
    }
}
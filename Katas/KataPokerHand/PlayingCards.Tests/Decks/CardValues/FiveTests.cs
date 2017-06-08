using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveTests
        : BaseCardValueTests <Five>
    {
        public FiveTests()
            : base('5',
                   "Five",
                   new[]
                   {
                       5u
                   })
        {
        }
    }
}
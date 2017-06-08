using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourTests
        : BaseCardValueTests <Four>
    {
        public FourTests()
            : base('4',
                   "Four",
                   new[]
                   {
                       4u
                   })
        {
        }
    }
}
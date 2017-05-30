using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourTests
        : BaseCardValueTests <Four>
    {
        public FourTests()
            : base("4",
                   new[]
                   {
                       4u
                   })
        {
        }
    }
}
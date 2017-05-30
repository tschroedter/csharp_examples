using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixTests
        : BaseCardValueTests <Six>
    {
        public SixTests()
            : base("6",
                   new[]
                   {
                       6u
                   })
        {
        }
    }
}
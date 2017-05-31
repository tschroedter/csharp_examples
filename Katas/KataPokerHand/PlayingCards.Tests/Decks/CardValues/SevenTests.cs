using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SevenTests
        : BaseCardValueTests <Seven>
    {
        public SevenTests()
            : base("7",
                   new[]
                   {
                       7u
                   })
        {
        }
    }
}
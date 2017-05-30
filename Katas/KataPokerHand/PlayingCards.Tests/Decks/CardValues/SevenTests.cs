using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

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
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class UnknownTests
        : BaseCardValueTests<Unknown>
    {
        public UnknownTests()
            : base("Unknown",
                   new[]
                   {
                       0u
                   })
        {
        }
    }
}
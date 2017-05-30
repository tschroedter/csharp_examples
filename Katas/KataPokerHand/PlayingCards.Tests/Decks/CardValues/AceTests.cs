using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class AceTests
        : BaseCardValueTests <Ace>
    {
        public AceTests()
            : base("Ace",
                   new[]
                   {
                       11u,
                       1u
                   })
        {
        }
    }
}
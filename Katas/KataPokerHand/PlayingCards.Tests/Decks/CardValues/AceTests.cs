using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

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
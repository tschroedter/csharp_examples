using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineTests
        : BaseCardValueTests <Nine>
    {
        public NineTests()
            : base("9",
                   new[]
                   {
                       9u
                   })
        {
        }
    }
}
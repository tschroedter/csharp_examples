using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineTests
        : BaseCardValueTests <Nine>
    {
        public NineTests()
            : base('9',
                   "Nine",
                   new[]
                   {
                       9u
                   })
        {
        }
    }
}
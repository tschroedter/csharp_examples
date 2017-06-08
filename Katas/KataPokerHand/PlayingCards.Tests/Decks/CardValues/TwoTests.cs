using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoTests
        : BaseCardValueTests <Two>
    {
        public TwoTests()
            : base('2',
                   "Two",
                   new[]
                   {
                       2u
                   })
        {
        }
    }
}
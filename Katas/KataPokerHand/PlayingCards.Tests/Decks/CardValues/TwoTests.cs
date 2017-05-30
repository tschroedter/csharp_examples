using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoTests
        : BaseCardValueTests <Two>
    {
        public TwoTests()
            : base("2",
                   new[]
                   {
                       2u
                   })
        {
        }
    }
}
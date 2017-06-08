using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenTests
        : BaseCardValueTests <Queen>
    {
        public QueenTests()
            : base('Q',
                   "Queen",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}
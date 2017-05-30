using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenTests
        : BaseCardValueTests <Queen>
    {
        public QueenTests()
            : base("Queen",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}
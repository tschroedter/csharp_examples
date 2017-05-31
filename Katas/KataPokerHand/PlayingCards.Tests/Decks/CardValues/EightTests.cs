using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightTests
        : BaseCardValueTests <Eight>
    {
        public EightTests()
            : base("8",
                   new[]
                   {
                       8u
                   })
        {
        }
    }
}
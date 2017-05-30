using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

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
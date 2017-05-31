using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class JacktTests
        : BaseCardValueTests <Jack>
    {
        public JacktTests()
            : base("Jack",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}
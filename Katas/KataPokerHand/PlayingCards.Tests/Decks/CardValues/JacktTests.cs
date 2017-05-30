using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.CardValues;
using NUnit.Framework;

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
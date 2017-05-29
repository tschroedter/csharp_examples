using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class KingTests
        : BaseCardValueTests <King>
    {
        public KingTests()
            : base("King",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}
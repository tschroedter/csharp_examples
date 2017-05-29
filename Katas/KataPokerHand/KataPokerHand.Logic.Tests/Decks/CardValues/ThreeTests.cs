using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeTests
        : BaseCardValueTests <Three>
    {
        public ThreeTests()
            : base("3",
                   new[]
                   {
                       3u
                   })
        {
        }
    }
}
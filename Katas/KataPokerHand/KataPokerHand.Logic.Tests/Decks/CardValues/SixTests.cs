using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixTests
        : BaseCardValueTests <Six>
    {
        public SixTests()
            : base("6",
                   new[]
                   {
                       6u
                   })
        {
        }
    }
}
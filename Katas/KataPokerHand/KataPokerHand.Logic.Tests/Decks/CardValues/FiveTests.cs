using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveTests
        : BaseCardValueTests <Five>
    {
        public FiveTests()
            : base("5",
                   new[]
                   {
                       5u
                   })
        {
        }
    }
}
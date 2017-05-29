using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourTests
        : BaseCardValueTests <Four>
    {
        public FourTests()
            : base("4",
                   new[]
                   {
                       4u
                   })
        {
        }
    }
}
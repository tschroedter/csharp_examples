using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SevenTests
        : BaseCardValueTests <Seven>
    {
        public SevenTests()
            : base("7",
                   new[]
                   {
                       7u
                   })
        {
        }
    }
}
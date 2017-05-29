using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoTests
        : BaseCardValueTests <Two>
    {
        public TwoTests()
            : base("2",
                   new[]
                   {
                       2u
                   })
        {
        }
    }
}
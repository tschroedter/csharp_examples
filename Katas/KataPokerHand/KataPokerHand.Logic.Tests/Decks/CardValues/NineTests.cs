using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineTests
        : BaseCardValueTests <Nine>
    {
        public NineTests()
            : base("9",
                   new[]
                   {
                       9u
                   })
        {
        }
    }
}
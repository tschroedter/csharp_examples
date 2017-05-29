using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class AceTests
        : BaseCardValueTests <Ace>
    {
        public AceTests()
            : base("Ace",
                   new[]
                   {
                       11u,
                       1u
                   })
        {
        }
    }
}
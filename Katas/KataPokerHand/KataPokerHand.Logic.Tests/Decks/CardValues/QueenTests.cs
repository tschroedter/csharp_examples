using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenTests
        : BaseCardValueTests <Queen>
    {
        public QueenTests()
            : base("Queen",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}
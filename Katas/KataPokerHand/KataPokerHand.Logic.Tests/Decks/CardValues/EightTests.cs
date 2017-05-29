using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightTests
        : BaseCardValueTests <Eight>
    {
        public EightTests()
            : base("8",
                   new[]
                   {
                       8u
                   })
        {
        }
    }
}
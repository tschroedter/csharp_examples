using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.CardValues;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class JacktTests
        : BaseCardValueTests <Jack>
    {
        public JacktTests()
            : base("Jack",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}
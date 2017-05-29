using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Suits;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SpadeTests
        : BaseSuitTests <Spade>
    {
        public SpadeTests()
            : base("Spade")
        {
        }
    }
}
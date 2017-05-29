using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Suits;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class HeartTests
        : BaseSuitTests <Heart>
    {
        public HeartTests()
            : base("Heart")
        {
        }
    }
}
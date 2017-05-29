using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.Suits;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Suits
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ClubTests
        : BaseSuitTests <Club>
    {
        public ClubTests()
            : base("Club")
        {
        }
    }
}
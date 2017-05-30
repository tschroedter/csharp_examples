using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.Suits;
using NUnit.Framework;

namespace Playing.Tests.Decks.Suits
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
using JetBrains.Annotations;
using PlayinCards.Interfaces;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public interface IPlayerHandInformation
    {
        [NotNull]
        IPlayerHand PlayerHand { get; }

        Status Status { get; set; }
        char Suit { get; set; }
        uint HighestCard { get; set; }
    }
}
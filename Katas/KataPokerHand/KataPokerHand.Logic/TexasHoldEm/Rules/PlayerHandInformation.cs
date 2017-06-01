using JetBrains.Annotations;
using PlayinCards.Interfaces;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class PlayerHandInformation
        : IPlayerHandInformation // todo testing
    {
        public PlayerHandInformation(
            [NotNull] IPlayerHand playerHand)
        {
            PlayerHand = playerHand;
            Status = Status.Unknown;
            Suit = UnknownSuit;
        }

        private const char UnknownSuit = ' ';

        public IPlayerHand PlayerHand { get; }
        public Status Status { get; set; }
        public char Suit { get; set; }
        public uint HighestCard { get; set; }
    }
}
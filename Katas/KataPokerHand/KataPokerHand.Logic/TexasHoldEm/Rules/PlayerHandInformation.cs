using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.Suits;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;

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
            Suit = UnknownSuit.Unknown;
            HighestCard = UnknownCard.Unknown;
        }

        public IPlayerHand PlayerHand { get; }
        public Status Status { get; set; }
        public ISuit Suit { get; set; }
        public ICard HighestCard { get; set; }
        public CardRank Rank { get; set; }
    }
}
using JetBrains.Annotations;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.Suits;

namespace KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules
{
    public interface IPlayerHandInformation
    {
        [NotNull]
        IPlayerHand PlayerHand { get; }
        Status Status { get; set; }
        [NotNull]
        ISuit Suit { get; set; }
        [NotNull]
        ICard HighestCard { get; set; }
        CardRank Rank { get; set; }
    }
}
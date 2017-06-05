using System.Collections.Generic;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public interface IFourCardsWithSameValueValidator
    {
        IEnumerable <ICard> Cards { get; set; }
        ICard OtherCard { get; }
        CardRank FourCardsRanks { get; }
        bool IsValid();
    }
}
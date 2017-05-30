using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.CardValues;
using PlayinCards.Interfaces.Decks.Suits;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class PokerDeck
        : IPokerDeck
    {
        [NotNull]
        private readonly List <ICard> m_Cards = new List <ICard>();

        [NotNull]
        private readonly IEnumerable <ICardValue> m_CardValues;

        [NotNull]
        private readonly IEnumerable <ISuit> m_Suits;

        public IEnumerable <ICard> Cards => m_Cards;

        public void Initialize()
        {
            m_Cards.Clear();
        }

        // todo
    }
}
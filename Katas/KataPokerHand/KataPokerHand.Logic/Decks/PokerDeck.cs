using System.Collections.Generic;
using JetBrains.Annotations;
using KataPokerHand.Logic.Decks.Cards;
using KataPokerHand.Logic.Interfaces.CardValues;
using KataPokerHand.Logic.Interfaces.Suits;

namespace KataPokerHand.Logic.Decks
{
    public class PokerDeck
        : IPokerDeck
    {
        public PokerDeck(
            [NotNull] IEnumerable <ISuit> suits,
            [NotNull] IEnumerable <ICardValue> cardValues)
        {
            m_Suits = suits;
            m_CardValues = cardValues;
        }

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

            foreach ( ISuit suit in m_Suits )
            {
                foreach ( ICardValue cardValue in m_CardValues )
                {
                    var card = new Card(suit,
                                        cardValue);

                    m_Cards.Add(card);
                }
            }
        }

        // todo
    }
}
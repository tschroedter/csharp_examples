using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards
{
    public class PlayerHand
        : IPlayerHand
    {
        public PlayerHand()
        {
        }

        public PlayerHand(
            [NotNull] IEnumerable <ICard> cards)
        {
            m_Cards.AddRange(cards);
        }

        public IEnumerable <ICard> Cards => m_Cards;
        private readonly StringBuilder m_Builder = new StringBuilder();

        private readonly List <ICard> m_Cards = new List <ICard>();

        public override string ToString()
        {
            m_Builder.Clear();

            foreach ( ICard card in m_Cards )
            {
                m_Builder.Append(card + " ");
            }

            return m_Builder.ToString().Trim();
        }
    }
}
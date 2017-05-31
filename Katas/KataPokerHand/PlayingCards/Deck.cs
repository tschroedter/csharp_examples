using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;

namespace PlayingCards
{
    public class Deck
        : IDeck
    {
        protected Deck(
            [NotNull] IRandom random,
            [NotNull] IPreviousCardValueFinder previous,
            [NotNull] INextCardValueFinder next,
            [NotNull] IEnumerable <ICard> cards)
        {
            m_Random = random;
            m_Previous = previous;
            m_Next = next;
            IEnumerable <ICard> cardsInDeck = cards as ICard[] ?? cards.ToArray();
            CardsInDeck = cardsInDeck;
            m_Cards = cardsInDeck.ToList();
        }

        [NotNull]
        private readonly INextCardValueFinder m_Next;

        [NotNull]
        private readonly IPreviousCardValueFinder m_Previous;

        [NotNull]
        private readonly IRandom m_Random;

        [NotNull]
        private IList <ICard> m_Cards;

        [NotNull]
        public IEnumerable <ICard> CardsInDeck { get; }

        [NotNull]
        public IEnumerable <ICard> Cards => m_Cards;

        public virtual char NextCardValue(char value)
        {
            return m_Next.NextCardValue(value);
        }

        public virtual char PreviousCardValue(char value)
        {
            return m_Previous.PreviousCardValue(value);
        }

        public virtual void Shuffle()
        {
            int cardsCount = m_Cards.Count;

            for ( var i = 0 ; i < cardsCount ; i++ )
            {
                int random = m_Random.Next(0,
                                           cardsCount);

                ICard tmp = m_Cards [ i ];
                m_Cards [ i ] = m_Cards [ random ];
                m_Cards [ random ] = tmp;
            }
        }

        public virtual void Reset()
        {
            m_Cards = CardsInDeck.ToList();
        }

        public virtual ICard DrawCard()
        {
            if ( !m_Cards.Any() )
            {
                return UnknownCard.Unknown;
            }

            ICard card = m_Cards.First();
            m_Cards.Remove(card);

            return card;
        }

        public virtual IEnumerable<ICard> DrawCards(int numberOfCards)
        {
            ICard[] list = m_Cards.Take(numberOfCards).ToArray();

            foreach ( ICard card in list )
            {
                m_Cards.Remove(card);
            }

            return list;
        }

        public int CardsLeftInDeck => m_Cards.Count;

        public bool AnyCardsLeftInDeck => m_Cards.Any();
    }
}
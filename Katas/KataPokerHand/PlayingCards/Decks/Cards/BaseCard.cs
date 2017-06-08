using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.CardValues;
using PlayinCards.Interfaces.Decks.Suits;

namespace PlayingCards.Decks.Cards
{
    public class BaseCard <TSuit, TCardValue>
        : ICard
        where TSuit : ISuit, new()
        where TCardValue : ICardValue, new()
    {
        public BaseCard()
        {
            m_Suit = new TSuit();
            m_Value = new TCardValue();
        }

        [NotNull]
        private readonly ISuit m_Suit;

        [NotNull]
        private readonly ICardValue m_Value;

        public CardRank Rank => m_Value.Rank;

        public ISuit GetSuit()
        {
            return m_Suit; // todo testing
        }

        public char Suit => m_Suit.AsChar; // todo test

        public char Value => m_Value.AsChar; // todo test

        public IEnumerable <uint> Values => m_Value.Values;

        public bool HasMultipleValues => m_Value.Values.Length > 1;

        public string Description()
        {
            return m_Value.Name + " of " + m_Suit.Name;
        }

        public override string ToString()
        {
            return m_Value.AsChar + m_Suit.AsChar.ToString();
        }
    }
}
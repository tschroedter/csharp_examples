using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.CardValues;
using PlayinCards.Interfaces.Decks.Suits;

namespace PlayingCards.Decks.Cards.Clubs
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

        public char Suit => m_Suit.AsChar;

        public uint Value => m_Value.Value;

        public IEnumerable <uint> Values => m_Value.Values;

        public bool HasMultipleValues => m_Value.Values.Length > 1;

        public override string ToString()
        {
            return m_Value.AsChar + m_Suit.AsChar.ToString();
        }
    }
}
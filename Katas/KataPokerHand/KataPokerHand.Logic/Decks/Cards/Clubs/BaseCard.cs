using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.Decks.CardValues;
using KataPokerHand.Logic.Interfaces.Decks.Suits;

namespace KataPokerHand.Logic.Decks.Cards.Clubs
{
    [DebuggerDisplay("{Suit}{Value}")]
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
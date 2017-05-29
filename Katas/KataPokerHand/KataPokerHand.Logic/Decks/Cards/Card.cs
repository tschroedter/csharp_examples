using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.CardValues;
using KataPokerHand.Logic.Interfaces.Suits;

namespace KataPokerHand.Logic.Decks.Cards
{
    [DebuggerDisplay("{Suit}{Value}")]
    public class Card
        : ICard
    {
        public Card(
            [NotNull] ISuit suit,
            [NotNull] ICardValue value)
        {
            m_Suit = suit;
            m_Value = value;
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
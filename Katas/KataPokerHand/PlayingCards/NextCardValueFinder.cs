using System.Collections.Generic;
using PlayinCards.Interfaces;
using PlayingCards.Decks.CardValues;

namespace PlayingCards
{
    public class NextCardValueFinder
        : INextCardValueFinder
    {   
        private readonly Dictionary <char, char> m_CardToNextCard =
            new Dictionary <char, char>()
            {
                { 'U', 'U' },
                { '2', '3' },
                { '3', '4' },
                { '4', '5' },
                { '5', '6' },
                { '6', '7' },
                { '7', '8' },
                { '8', '9' },
                { '9', 'J' },
                { 'J', 'Q' },
                { 'Q', 'K' },
                { 'K', 'A' },
                { 'A', 'U' },
            };

        public char NextCard(char current)
        {
            char next;

            return !m_CardToNextCard.TryGetValue(current,
                                                 out next)
                       ? Unknown.UnknownCardValue.AsChar
                       : next;
        }
    }
}

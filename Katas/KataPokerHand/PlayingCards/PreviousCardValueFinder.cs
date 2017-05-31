using System.Collections.Generic;
using PlayinCards.Interfaces;
using PlayingCards.Decks.CardValues;

namespace PlayingCards
{
    public class PreviousCardValueFinder
        : IPreviousCardValueFinder
    {
        private readonly Dictionary <char, char> m_CardToNextCard =
            new Dictionary <char, char>
            {
                {
                    'U', 'U'
                },
                {
                    '2', 'U'
                },
                {
                    '3', '2'
                },
                {
                    '4', '3'
                },
                {
                    '5', '4'
                },
                {
                    '6', '5'
                },
                {
                    '7', '6'
                },
                {
                    '8', '7'
                },
                {
                    '9', '8'
                },
                {
                    'J', '9'
                },
                {
                    'Q', 'J'
                },
                {
                    'K', 'Q'
                },
                {
                    'A', 'K'
                }
            };

        public char PreviousCardValue(char current)
        {
            char next;

            return !m_CardToNextCard.TryGetValue(current,
                                                 out next)
                       ? Unknown.UnknownCardValue.AsChar
                       : next;
        }
    }
}
using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.CardValues;

namespace PlayingCards.Decks.CardValues
{
    [DebuggerDisplay("{Name} = {Value}")]
    public abstract class BaseCardValue
        : ICardValue
    {
        protected BaseCardValue(
            char asChar,
            [NotNull] string name,
            [NotNull] uint[] values,
            CardRank rank)
        {
            if ( string.IsNullOrEmpty(name) )
            {
                throw new ArgumentException(
                                            "Card value 'name' can't be null or empty!",
                                            nameof(name));
            }

            if ( !values.Any() )
            {
                throw new ArgumentException(
                                            "Card values 'values' can't be empty!",
                                            nameof(name));
            }

            Name = name;
            AsChar = asChar;
            Values = values;
            Value = values [ 0 ];
            Rank = rank; // todo testing
        }

        [NotNull]
        public string Name { get; }

        [NotNull]
        public uint[] Values { get; }

        public uint Value { get; }

        public char AsChar { get; }

        public CardRank Rank { get; }

        public override string ToString()
        {
            return AsChar.ToString();
        }
    }
}
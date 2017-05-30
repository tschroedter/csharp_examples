using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.CardValues;

namespace PlayingCards.Decks.CardValues
{
    [DebuggerDisplay("{Name} = {Value}")]
    public abstract class BaseCardValue
        : ICardValue
    {
        protected BaseCardValue(
            [NotNull] string name,
            [NotNull] uint[] values)
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
            AsChar = name [ 0 ];
            Values = values;
            Value = values [ 0 ];
        }

        [NotNull]
        public string Name { get; }

        [NotNull]
        public uint[] Values { get; }

        public uint Value { get; }

        public char AsChar { get; }

        public override string ToString()
        {
            return AsChar.ToString();
        }
    }
}
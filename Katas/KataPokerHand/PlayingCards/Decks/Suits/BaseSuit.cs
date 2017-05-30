using System;
using System.Diagnostics;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Suits;

namespace PlayingCards.Decks.Suits
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public abstract class BaseSuit
        : ISuit
    {
        protected BaseSuit(
            [NotNull] string name)
        {
            if ( string.IsNullOrEmpty(name) )
            {
                throw new ArgumentException(
                                            "Suit 'name' can't be null or empty!",
                                            nameof(name));
            }

            Name = name;
            AsChar = name [ 0 ];
        }

        [NotNull]
        public string Name { get; }

        public char AsChar { get; }

        public override string ToString()
        {
            return AsChar.ToString();
        }
    }
}
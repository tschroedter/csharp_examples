using System;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.Suits;

namespace KataPokerHand.Logic.Suits
{
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
            Id = name [ 0 ].ToString();
        }

        [NotNull]
        public string Name { get; }

        public string Id { get; }
    }
}
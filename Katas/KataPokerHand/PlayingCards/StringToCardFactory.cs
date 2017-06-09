using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;

namespace PlayingCards
{
    public sealed class StringToCardFactory
        : IStringToCardFactory
    {
        private readonly Dictionary <string, Type> m_Dictionary = new Dictionary <string, Type>();

        [NotNull]
        public ICard ToCard(string name)
        {
            // todo use IoC container factory
            Type type;

            if ( !m_Dictionary.TryGetValue(name.ToLower(),
                                           out type) )
            {
                type = typeof( UnknownCard );
            }

            return CreateCard(type);
        }

        public void Initialize(IEnumerable <ICard> cards)
        {
            foreach ( ICard card in cards )
            {
                m_Dictionary.Add(card.Description().ToLower(),
                                 card.GetType());
            }
        }

        private ICard CreateCard(Type type)
        {
            return ( ICard ) Activator.CreateInstance(type);
        }
    }
}
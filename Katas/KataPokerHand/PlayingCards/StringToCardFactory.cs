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
        private readonly Dictionary <string, Type> m_DictionaryByDescription = new Dictionary <string, Type>();
        private readonly Dictionary<string, Type> m_DictionaryToString = new Dictionary<string, Type>();

        [NotNull]
        public ICard ToCard(string name)
        {
            // todo use IoC container factory
            Type type;

            if ( m_DictionaryByDescription.TryGetValue(name.ToLower(),
                                                       out type) )
            {
                return CreateCard(type);
            }

            if (m_DictionaryToString.TryGetValue(name.ToLower(),    // todo testing 2C, ...
                                                      out type))
            {
                return CreateCard(type);
            }

            type = typeof( UnknownCard );

            return CreateCard(type);
        }

        public void Initialize(IEnumerable <ICard> cards)
        {
            foreach ( ICard card in cards )
            {
                m_DictionaryByDescription.Add(card.Description().ToLower(),
                                 card.GetType());

                m_DictionaryByDescription.Add(card.ToString().ToLower(), // todo testing 2C, ...
                                              card.GetType());
            }
        }

        private ICard CreateCard(Type type)
        {
            return ( ICard ) Activator.CreateInstance(type);
        }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayinCards.Interfaces
{
    public interface IStringToCardFactory
    {
        void Initialize(IEnumerable <ICard> cards);
        ICard ToCard([NotNull] string name);
    }
}
using System;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards
{
    public sealed class StringToCardRankFactory
        : IStringToCardRankFactory
    {
        public CardRank ToCardRank(string name)
        {
            string text = name.Trim().Replace(" ",
                                              "").ToLower();

            CardRank rank;

            return Enum.TryParse(text,
                                 true,
                                 out rank)
                       ? rank
                       : CardRank.Unknown;
        }
    }
}
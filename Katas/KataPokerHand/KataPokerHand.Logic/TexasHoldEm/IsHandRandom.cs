using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class IsHandRandom
    {
        public bool IsTrue(
            [NotNull] IHand hand)
        {
            IEnumerable <IGrouping <char, ICard>> groupedBySuits =
                hand.Cards
                    .GroupBy(x => x.Suit);


            //            IEnumerable <ICard> suits = 
            //                hand.Cards
            //                    .GroupBy(x => x.Suit)
            //                    .Select(group => group.First());
            // todo
            return false;
        }
    }

    public class IsStraightFlush
    {
        public bool IsTrue(
            [NotNull] IHand hand)
        {
            IEnumerable <IGrouping <char, ICard>> groupedBySuits =
                hand.Cards
                    .GroupBy(x => x.Suit);

            IEnumerable <ICard> suitsInHand = groupedBySuits.Select(group => group.First());


            //            IEnumerable <ICard> suits = 
            //                hand.Cards
            //                    .GroupBy(x => x.Suit)
            //                    .Select(group => group.First());
            // todo
            return false;
        }
    }

    public interface IHand
    {
        IEnumerable <ICard> Cards { get; }
    }
}
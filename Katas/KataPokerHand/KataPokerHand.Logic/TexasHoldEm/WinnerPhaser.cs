using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm
{
    public class WinnerPhaser
        : IWinnerPhaser
    {
        // todo testing
        // todo continue here
        public WinnerPhaser(
            [NotNull] ICardsRankEngine phaseOne,
            
            [NotNull] ICardsRanking phaseTwo)
        {
            m_PhaseOne = phaseOne;
            m_PhaseTwo = phaseTwo;
        }

        [NotNull]
        private readonly ICardsRankEngine m_PhaseOne;

        [NotNull]
        private readonly ICardsRanking m_PhaseTwo;

        public void Phase(
            IEnumerable <IEnumerable <ICard>> cards)
        {
            IEnumerable <IPlayerHandInformation> infos = CreatePlayerHandInformations(cards).ToArray();

            m_PhaseOne.ApplyRules(infos);
            m_PhaseTwo.Apply(infos);
        }

        private IEnumerable <IPlayerHandInformation> CreatePlayerHandInformations(
            [NotNull] IEnumerable <IEnumerable <ICard>> cardsList)
        {
            var infos = new List <IPlayerHandInformation>();

            foreach ( IEnumerable <ICard> cards in cardsList )
            {
                var info = new PlayerHandInformation
                           {
                               Cards = cards
                           };

                infos.Add(info);
            }

            return infos;
        }


        public WinnerStatus Winner => m_PhaseTwo.Winner;
        public IPlayerHandInformation WinnerInformation => m_PhaseTwo.WinnerInformation;
    }

    public interface IWinnerPhaser
    {
        WinnerStatus Winner { get; }
        [NotNull]
        IPlayerHandInformation WinnerInformation { get; }

        void Phase(
            [NotNull] IEnumerable <IEnumerable <ICard>> cards);
    }
}
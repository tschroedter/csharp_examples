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
            [NotNull] IPlayerInformationGroupedByStatus phaseOneOne,
            [NotNull] ICardsRanking phaseTwo)
        {
            m_PhaseOne = phaseOne;
            m_PhaseOneOne = phaseOneOne;
            m_PhaseTwo = phaseTwo;
        }

        [NotNull]
        private readonly ICardsRankEngine m_PhaseOne;

        [NotNull]
        private readonly IPlayerInformationGroupedByStatus m_PhaseOneOne;

        [NotNull]
        private readonly ICardsRanking m_PhaseTwo;

        public void Phase(
            [NotNull] IEnumerable <IEnumerable <ICard>> cards)
        {
            IEnumerable <IPlayerHandInformation> infos = CreatePlayerHandInformations(cards).ToArray();

            m_PhaseOne.ApplyRules(infos);
            m_PhaseOneOne.Group(infos);
            m_PhaseTwo.Apply(m_PhaseOneOne.All());

            // todo build ranking, m_PhaseTwo should do that
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
    }

    public interface ICardsRanking
    {
        void Apply(IEnumerable <IPlayerHandInformation> infos);
    }

    public interface IWinnerPhaser
    {
    }

    public class CardsRanking
        : ICardsRanking // todo testing ISameStatusRanking[]
    {
        private readonly IEnumerable <ISameStatusRanking> m_Rankings;

        public CardsRanking(
            [NotNull] IEnumerable <ISameStatusRanking> rankings)
        {
            m_Rankings = rankings;
        }

        public void Apply(IEnumerable <IPlayerHandInformation> infos)
        {
            throw new System.NotImplementedException(); // todo
        }
    }
}
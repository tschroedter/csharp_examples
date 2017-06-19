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
            [NotNull] IEnumerable <IEnumerable <ICard>> cards)
        {
            IEnumerable <IPlayerHandInformation> infos = CreatePlayerHandInformations(cards).ToArray();

            m_PhaseOne.ApplyRules(infos);
            m_PhaseTwo.Rank(infos);

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
        void Rank([NotNull] IEnumerable <IPlayerHandInformation> infos);
    }

    public interface IWinnerPhaser
    {
    }

    public class CardsRanking
        : ICardsRanking // todo testing
    {
        [NotNull]
        private readonly IRankByHighCards m_RankByHighCards;

        public CardsRanking(
            [NotNull] IRankByHighCards rankByHighCards)
        {
            m_RankByHighCards = rankByHighCards;
        }

        [NotNull]
        private readonly List <IPlayerHandInformation> m_Ranking = 
            new List <IPlayerHandInformation>();

        public CardsRanking(
            [NotNull] IPlayerInformationGroupedByStatus grouped)
        {
            m_Grouped = grouped;
        }

        [NotNull]
        private readonly IPlayerInformationGroupedByStatus m_Grouped;

        public void Rank(IEnumerable <IPlayerHandInformation> infos)
        {
            m_Ranking.Clear();
            m_Grouped.Group(infos);

            foreach ( Status status in m_Grouped.Keys() )
            {
                IPlayerHandInformation[] infosForStatus = m_Grouped.Values(status).ToArray();

                switch ( infosForStatus.Length )
                {   // todo
                    case 0:
                        break;
                    case 1:
                        m_Ranking.Add(infosForStatus.First());
                        break;
                    default:
                        m_RankByHighCards.Rank(status, infosForStatus);
                        m_Ranking.AddRange(m_RankByHighCards.Ranked);
                        break;
                }
            }
        }
    }

    public class RankByHighCards
        : IRankByHighCards // todo testing
    {
        [NotNull]
        private readonly IEnumerable <ISameStatusRanking> m_Rankings;

        public RankByHighCards(
            [NotNull] IEnumerable <ISameStatusRanking> rankings)
        {
            m_Rankings = rankings;
        }

        [NotNull]
        private readonly List <IPlayerHandInformation> m_Ranked = 
            new List <IPlayerHandInformation>();

        public void Rank(Status status,
                         IPlayerHandInformation[] infos)
        {
            m_Ranked.Clear();

            if ( infos.Length == 0 )
            {
                return;
            }

            foreach ( ISameStatusRanking ranking in m_Rankings )
            {
                if ( !ranking.CanApply(status) )
                {
                    continue;
                }

                ranking.Apply(infos);

                m_Ranked.AddRange(ranking.Ranked);
            }
        }

        public IEnumerable <IPlayerHandInformation> Ranked => m_Ranked;
    }
}
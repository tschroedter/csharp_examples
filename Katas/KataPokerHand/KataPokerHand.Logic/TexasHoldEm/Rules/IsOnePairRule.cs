using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using Rules.Logic.Interfaces.Rules;
using Rules.Logic.Rules;

namespace KataPokerHand.Logic.TexasHoldEm.Rules
{
    public class IsOnePairRule
        : BaseRule <IPlayerHandInformation>,
          IRule <IPlayerHandInformation>
    {
        public IsOnePairRule(
            [NotNull] IIsOnePairCondition onePairsCondition,
            [NotNull] IOnePairValidator validator)
        {
            m_OnePairsCondition = onePairsCondition;
            m_Validator = validator;
        }

        [NotNull]
        private readonly IIsOnePairCondition m_OnePairsCondition;

        [NotNull]
        private readonly IOnePairValidator m_Validator;

        public override IPlayerHandInformation Apply(IPlayerHandInformation info)
        {
            m_Validator.Cards = info.Cards;

            if ( !m_Validator.IsValid() )
            {
                return info;
            }

            info.Status = Status.OnePair;
            info.PairOfCards = m_Validator.PairOfCards;
            info.OtherCards = m_Validator.OtherCards;
            info.HighestCard = m_Validator.HighestCard;

            return info;
        }

        public override void Initialize(IPlayerHandInformation info)
        {
            m_OnePairsCondition.Cards = info.Cards.ToArray();

            Conditions.Add(m_OnePairsCondition);
        }

        public override int GetPriority()
        {
            return ( int ) RulesPriority.OnePairs;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic
{
    public class RuleRepository <T> : IRuleRepository <T>
    {
        public RuleRepository()
        {
        }

        public RuleRepository([NotNull] IEnumerable <IRule <T>> rules)
        {
            m_Rules.AddRange(rules.OrderBy(x => x.Priority));
        }

        private readonly List <IRule <T>> m_Rules = new List <IRule <T>>();

        public IEnumerable <IRule <T>> Rules => m_Rules;

        public void Add(IRule <T> rule)
        {
            Update(rule);
        }

        public void Delete(IRule <T> rule)
        {
            m_Rules.Remove(rule);
        }

        public void Update(IRule <T> rule)
        {
            if ( m_Rules.Contains(rule) )
            {
                m_Rules.Remove(rule);
            }

            m_Rules.Add(rule);
            IRule <T>[] sorted = m_Rules.OrderBy(x => x.Priority).ToArray();
            m_Rules.Clear();
            m_Rules.AddRange(sorted);
        }
    }
}
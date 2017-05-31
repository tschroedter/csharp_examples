using System.Collections.Generic;
using System.Linq;
using Rules.Logic.Interfaces.Conditions;

namespace Rules.Logic.Rules
{
    public abstract class BaseRule <T>
    {
        protected List <ICondition> Conditions { get; } = new List <ICondition>();

        public int Priority => GetPriority();

        public abstract T Apply(T info);

        public void ClearConditions()
        {
            Conditions.Clear();
        }

        public IEnumerable <ICondition> GetConditions()
        {
            return Conditions;
        }

        public abstract int GetPriority();

        public abstract void Initialize(T info);

        public bool IsValid()
        {
            return Conditions.All(x => x.IsSatisfied());
        }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic
{
    public interface IRuleRepository <T>
    {
        [NotNull]
        IEnumerable <IRule <T>> Rules { get; }

        void Add([NotNull] IRule <T> rule);
        void Delete([NotNull] IRule <T> rule);
        void Update([NotNull] IRule <T> rule);
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Rules.Logic.Interfaces
{
    public interface IEngine <in T>
    {
        void ApplyRules([NotNull] IEnumerable <T> cells);
    }
}
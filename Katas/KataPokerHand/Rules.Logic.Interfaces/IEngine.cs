using System.Collections.Generic;
using JetBrains.Annotations;

namespace Rules.Logic.Interfaces
{
    public interface IEngine <T>
    {
        void ApplyRules([NotNull] IEnumerable <T> cells);
    }
}
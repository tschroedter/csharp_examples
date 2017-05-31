using System.Collections.Generic;
using Rules.Logic.Interfaces.Rules;

namespace Rules.Logic
{
    public interface IRuleRepository <T>
    {
        IEnumerable <IRule <T>> Rules { get; }
    }
}
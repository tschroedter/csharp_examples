using System.Collections.Generic;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces
{
    public interface ISubTotalCalculator
    {
        double Total { get; }
        void Calculate([NotNull] IEnumerable <IReceiptItem> items);
    }
}
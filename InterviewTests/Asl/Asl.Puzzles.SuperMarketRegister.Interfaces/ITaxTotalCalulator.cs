using System.Collections.Generic;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces
{
    public interface ITaxTotalCalulator
    {
        double Percentage { get; }
        double Total { get; }
        void Calculate([NotNull] IEnumerable <IReceiptItem> items);
    }
}
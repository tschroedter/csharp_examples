using System.Collections.Generic;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces
{
    public interface ITotalCalculator
    {
        double TaxTotal { get; set; }
        double SubTotal { get; set; }
        double Total { get; }
        void Calculate([NotNull] [UsedImplicitly] IEnumerable <IReceiptItem> items);
    }
}
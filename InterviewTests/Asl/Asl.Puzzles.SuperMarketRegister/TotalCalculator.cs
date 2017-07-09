using System.Collections.Generic;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister
{
    [UsedImplicitly]
    public class TotalCalculator
        : ITotalCalculator
    {
        public void Calculate(IEnumerable <IReceiptItem> items)
        {
            Total = SubTotal + TaxTotal;
        }

        public double TaxTotal { get; set; }

        public double SubTotal { get; set; }

        public double Total { get; private set; }
    }
}
using System.Collections.Generic;
using System.Linq;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister
{
    [UsedImplicitly]
    public class SubTotalCalculator
        : ISubTotalCalculator
    {
        public void Calculate(IEnumerable <IReceiptItem> items)
        {
            Total = items.Sum(x => x.Total);
        }

        public double Total { get; private set; }
    }
}
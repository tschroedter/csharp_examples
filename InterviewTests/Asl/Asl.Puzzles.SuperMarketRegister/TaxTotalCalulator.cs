using System.Collections.Generic;
using System.Linq;
using Asl.Puzzles.SuperMarketRegister.Interfaces;

namespace Asl.Puzzles.SuperMarketRegister
{
    public class TaxTotalCalulator
        : ITaxTotalCalulator
    {
        public TaxTotalCalulator()
        {
            Percentage = 10.0d;
        }

        public double Percentage { get; }
        public double Total { get; private set; }

        public void Calculate(IEnumerable <IReceiptItem> items)
        {
            double itemsTotal = items.Sum(x => x.Total);

            Total = itemsTotal * ( Percentage / 100.0d );
        }
    }
}
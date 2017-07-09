using System.Text;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister
{
    public class Receipt
        : IReceipt
    {
        private readonly IReceiptItemList m_List;
        private readonly ISubTotalCalculator m_SubTotalCalculator;
        private readonly ITaxTotalCalulator m_TaxTotalCalulator;
        private readonly ITotalCalculator m_TotalCalculator;

        public Receipt(
            [NotNull] IReceiptItemList list,
            [NotNull] ISubTotalCalculator subTotalCalculator,
            [NotNull] ITaxTotalCalulator taxTotalCalulator,
            [NotNull] ITotalCalculator totalCalculator)
        {
            m_List = list;
            m_SubTotalCalculator = subTotalCalculator;
            m_TaxTotalCalulator = taxTotalCalulator;
            m_TotalCalculator = totalCalculator;
        }

        public void AddItem(
            int quantity,
            string itemDescription,
            double pricePerItem)
        {
            var item = new ReceiptItem(quantity,
                                       itemDescription,
                                       pricePerItem);

            m_List.AddItem(item);

            Calculate();
        }

        public void Calculate()
        {
            m_SubTotalCalculator.Calculate(m_List.Items);

            m_TaxTotalCalulator.Calculate(m_List.Items);

            m_TotalCalculator.SubTotal = m_SubTotalCalculator.Total;
            m_TotalCalculator.TaxTotal = m_TaxTotalCalulator.Total;
            m_TotalCalculator.Calculate(m_List.Items);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(m_List.ToString());
            builder.AppendLine($"SubTotal = ${m_SubTotalCalculator.Total:F2}");
            builder.AppendLine($"Tax ({m_TaxTotalCalulator.Percentage:F0}%) = ${m_TaxTotalCalulator.Total:F2}");
            builder.AppendLine($"Total = ${m_TotalCalculator.Total:F2}");

            return builder.ToString();
        }
    }
}
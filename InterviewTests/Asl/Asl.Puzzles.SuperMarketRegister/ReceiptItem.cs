using Asl.Puzzles.SuperMarketRegister.Interfaces;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister
{
    public class ReceiptItem
        : IReceiptItem
    {
        private const string DescriptionFormat = "{0} {1} @ ${2:F2} = ${3:F2}"; // todo use Money class

        public ReceiptItem(
            int quantity,
            [NotNull] string itemDescription,
            double pricePerItem)
        {
            Quantity = quantity;
            ItemDescription = itemDescription;
            PricePerItem = pricePerItem;
            Total = quantity * pricePerItem;
            Description = string.Format(DescriptionFormat,
                                        Quantity,
                                        ItemDescription,
                                        PricePerItem,
                                        Total);
        }

        private string Description { get; }

        public int Quantity { get; }
        public string ItemDescription { get; }
        public double PricePerItem { get; }
        public double Total { get; }

        public override string ToString()
        {
            return Description;
        }
    }
}
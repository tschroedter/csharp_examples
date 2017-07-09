using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces
{
    public interface IReceipt
    {
        void AddItem(
            int quantity,
            [NotNull] string itemDescription,
            double pricePerItem);

        string ToString();

        [UsedImplicitly]
        void Calculate();
    }
}
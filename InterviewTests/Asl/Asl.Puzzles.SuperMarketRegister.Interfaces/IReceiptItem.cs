namespace Asl.Puzzles.SuperMarketRegister.Interfaces
{
    public interface IReceiptItem
    {
        int Quantity { get; }
        string ItemDescription { get; }
        double PricePerItem { get; }
        double Total { get; }
    }
}
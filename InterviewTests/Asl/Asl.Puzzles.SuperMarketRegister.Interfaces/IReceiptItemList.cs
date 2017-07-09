using System.Collections.Generic;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister.Interfaces
{
    public interface IReceiptItemList
    {
        [NotNull]
        IEnumerable <IReceiptItem> Items { get; }

        [UsedImplicitly]
        int Count { get; }

        void AddItem([NotNull] IReceiptItem item);
        string ToString();
    }
}
using System.Collections.Generic;
using System.Text;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using JetBrains.Annotations;

namespace Asl.Puzzles.SuperMarketRegister
{
    [UsedImplicitly]
    public class ReceiptItemList
        : IReceiptItemList
    {
        private readonly List <IReceiptItem> m_Items = new List <IReceiptItem>();

        public void AddItem(IReceiptItem item)
        {
            m_Items.Add(item);
        }

        public int Count => m_Items.Count;

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach ( IReceiptItem item in m_Items )
            {
                builder.AppendLine(item.ToString());
            }

            return builder.ToString();
        }

        public IEnumerable <IReceiptItem> Items => m_Items.ToArray();
    }
}
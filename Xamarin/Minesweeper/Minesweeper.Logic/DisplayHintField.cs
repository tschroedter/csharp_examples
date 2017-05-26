using System.Text;
using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class DisplayHintField : IDisplayHintField
    {
        public DisplayHintField([NotNull] IHintField field)
        {
            m_Field = field;
        }

        private readonly IHintField m_Field;
        private readonly int Mine = -1;

        public override string ToString()
        {
            var builder = new StringBuilder();

            for ( var rows = 0 ; rows < m_Field.RowsCount ; rows++ )
            {
                for ( var columns = 0 ; columns < m_Field.ColumnsCount ; columns++ )
                {
                    int value = m_Field.GetHintFor(rows,
                                                   columns);

                    string displayValue = value == Mine
                                              ? "*"
                                              : value.ToString();

                    builder.Append(displayValue);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
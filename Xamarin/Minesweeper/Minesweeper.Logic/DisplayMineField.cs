using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class DisplayMineField : IDisplayMineField
    {
        public DisplayMineField([NotNull] IMineField mineField)
        {
            m_MineField = mineField;
        }

        private readonly IMineField m_MineField;

        public override string ToString()
        {
            var builder = new StringBuilder();

            IEnumerable <IEnumerable <bool>> rows = m_MineField.Rows();

            foreach ( IEnumerable <bool> row in rows )
            {
                string rowAsString = ConvertRowToString(row);

                builder.AppendLine(rowAsString);
            }

            return builder.ToString();
        }

        private string ConvertRowToString([NotNull] IEnumerable <bool> row)
        {
            var builder = new StringBuilder();

            foreach ( bool column in row )
            {
                string text = column
                                  ? "*"
                                  : ".";

                builder.Append(text);
            }

            return builder.ToString();
        }
    }
}
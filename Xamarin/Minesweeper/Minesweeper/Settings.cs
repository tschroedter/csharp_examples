using System.Diagnostics;
using Android.Content;

namespace Minesweeper
{
    [DebuggerDisplay("Rows = {NumberOfRows}, Columns = {NumberOfColumns}, Mines = {NumberOfMines}")]
    public class Settings
        : ISettings
    {
        public Settings()
        {
            NumberOfColumns = DefaultNumberOfColumns;
            NumberOfRows = DefaultNumberOfRows;
            NumberOfMines = DefaultNumberOfMines;
        }

        private const string KeyNumberOfColumns = "SettingsNumberOfColumns";
        private const string KeyNumberOfRows = "SettingsNumberOfRows";
        private const string KeyNumberOfMines = "SettingsNumberOfMines";
        private const int DefaultNumberOfColumns = 3;
        private const int DefaultNumberOfRows = 3;
        private const int DefaultNumberOfMines = 2;
        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfMines { get; set; }

        public void ReadSettingFromIntent(Intent intent)
        {
            NumberOfColumns = intent.GetIntExtra(KeyNumberOfColumns,
                                                 DefaultNumberOfColumns);

            NumberOfRows = intent.GetIntExtra(KeyNumberOfRows,
                                              DefaultNumberOfRows);

            NumberOfMines = intent.GetIntExtra(KeyNumberOfMines,
                                               DefaultNumberOfMines);
        }

        public void WriteSettingToIntent(Intent intent)
        {
            intent.PutExtra(KeyNumberOfColumns,
                            NumberOfColumns);

            intent.PutExtra(KeyNumberOfRows,
                            NumberOfRows);

            intent.PutExtra(KeyNumberOfMines,
                            NumberOfMines);
        }
    }
}
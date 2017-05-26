using Android.Content;

namespace Minesweeper
{
    public interface ISettings
    {
        int NumberOfColumns { get; set; }
        int NumberOfRows { get; set; }
        int NumberOfMines { get; set; }
        void ReadSettingFromIntent(Intent bundle);
        void WriteSettingToIntent(Intent bundle);
    }
}
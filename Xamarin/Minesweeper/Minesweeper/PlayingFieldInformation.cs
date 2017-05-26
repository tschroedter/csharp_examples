namespace Minesweeper
{
    public class PlayingFieldInformation
    {
        public long Id { get; set; }
        public int Hint { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsSelected { get; set; }
        public string DisplayText { get; set; }
        public int BackgroundResource { get; set; }
    }
}
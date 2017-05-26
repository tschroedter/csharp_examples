namespace Minesweeper.Logic.Interfaces
{
    public class GameStatus
    {
        public enum Player
        {
            SelectedFieldWithMine,
            SelectedFieldWithoutMine,
            HasWon
        }
    }
}
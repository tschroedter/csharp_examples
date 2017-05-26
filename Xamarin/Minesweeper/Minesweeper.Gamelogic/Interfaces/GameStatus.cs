namespace Minesweeper.Gamelogic.Interfaces
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
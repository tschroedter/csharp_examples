namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IHintCompass
    {
        int GetMineCountFor(int rowIndex,
                            int columnIndex);
    }
}
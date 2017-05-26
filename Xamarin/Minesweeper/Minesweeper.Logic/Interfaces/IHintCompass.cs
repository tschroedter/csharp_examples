namespace Minesweeper.Logic.Interfaces
{
    public interface IHintCompass
    {
        int GetMineCountFor(int rowIndex,
                            int columnIndex);
    }
}
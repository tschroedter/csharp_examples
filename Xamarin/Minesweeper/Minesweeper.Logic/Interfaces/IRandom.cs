namespace Minesweeper.Logic.Interfaces
{
    public interface IRandom
    {
        int Next(int minimum,
                 int maximum);
    }
}
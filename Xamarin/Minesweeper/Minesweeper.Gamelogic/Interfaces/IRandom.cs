namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IRandom
    {
        int Next(int minimum,
                 int maximum);
    }
}
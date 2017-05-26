using Minesweeper.Gamelogic.Interfaces;
using Minesweeper.Gamelogic.Ioc;

namespace Minesweeper.Gamelogic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MinesweeperConsole 
        : IConsole
    {
        public void WriteLine(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }

        public void WriteLine(string format,
                              params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(format,
                                               args);
        }
    }
}
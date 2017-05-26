using System;
using System.Diagnostics;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MinesweeperConsole
        : IConsole
    {
        public void WriteLine(string text)
        {
            Debug.WriteLine(text);
        }

        public void WriteLine(string format,
                              params object[] args)
        {
            Debug.WriteLine(format,
                            args);
        }

        public void Write(string text)
        {
            Debug.Write(text);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
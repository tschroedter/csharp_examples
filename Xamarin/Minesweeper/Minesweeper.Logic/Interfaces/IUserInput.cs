using System;

namespace Minesweeper.Logic.Interfaces
{
    public interface IUserInput
    {
        Tuple <int, int> AskUserForRowAndCoumn(int maximumRow,
                                               int maximumColumn);
    }
}
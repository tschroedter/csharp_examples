using System;

namespace Minesweeper.Gamelogic.Interfaces
{
    public interface IUserInput
    {
        Tuple <int, int> AskUserForRowAndCoumn(int maximumRow,
                                               int maximumColumn);
    }
}
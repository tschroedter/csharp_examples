using System;
using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class Game : IGame
    {
        public Game([NotNull] IConsole console,
                    [NotNull] IMineFieldManager manager)
        {
            m_Console = console;
            m_Manager = manager;
        }

        private readonly IConsole m_Console;
        private readonly IMineFieldManager m_Manager;

        public GameStatus.Player Status
        {
            get
            {
                return m_Manager.Status;
            }
        }

        public int RowsCount
        {
            get
            {
                return m_Manager.RowsCount;
            }
        }

        public int ColumnsCount
        {
            get
            {
                return m_Manager.ColumsCount;
            }
        }

        public void Initialize(int numberOfRows,
                               int numberOfColumns,
                               int numberOfMines)
        {
            m_Manager.CreateMineField(numberOfRows,
                                      numberOfColumns,
                                      numberOfMines);

            m_Manager.DisplayPlayingField();
        }

        public void Start()
        {
            bool isFinished;

            do
            {
                isFinished = PlayOneRound();
            }
            while ( !isFinished );
        }

        public bool PlayOneRound(int row,
                                 int column)
        {
            m_Manager.UserSelectedField(row,
                                        column);

            m_Manager.DisplayPlayingField();

            bool isFinished = IsGameFinished(m_Manager.Status);

            return isFinished;
        }

        public bool IsGameFinished(GameStatus.Player status)
        {
            switch ( status )
            {
                case GameStatus.Player.SelectedFieldWithMine:
                    m_Console.WriteLine("You hit a mine!");
                    return true;

                case GameStatus.Player.SelectedFieldWithoutMine:
                    return false;

                case GameStatus.Player.HasWon:
                    m_Console.WriteLine("You won!");
                    return true;

                default:
                    throw new Exception("Unknown Status: " + m_Manager.Status);
            }
        }

        public string GameStatusToString(GameStatus.Player status)
        {
            switch ( status )
            {
                case GameStatus.Player.SelectedFieldWithMine:
                    return "You hit a mine!";

                case GameStatus.Player.SelectedFieldWithoutMine:
                    return "Selected Field Without Mine!";

                case GameStatus.Player.HasWon:
                    return "You won!";

                default:
                    throw new Exception("Unknown Status: " + m_Manager.Status);
            }
        }

        public int GetHintFor(int row,
                              int column)
        {
            return m_Manager.GetHintFor(row,
                                        column);
        }

        public bool PlayOneRound()
        {
            Tuple <int, int> rowAndColumn = m_Manager.AskUserForRowAndCoumn(m_Manager.RowsCount - 1,
                                                                            m_Manager.ColumsCount - 1);

            int row = rowAndColumn.Item1;
            int column = rowAndColumn.Item2;

            return PlayOneRound(row,
                                column);
        }
    }
}
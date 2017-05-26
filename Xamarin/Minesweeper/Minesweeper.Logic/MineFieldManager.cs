using System;
using JetBrains.Annotations;
using Minesweeper.Logic.Interfaces;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MineFieldManager : IMineFieldManager
    {
        public MineFieldManager([NotNull] IStringToMineFieldConverter converter,
                                [NotNull] MineField.Factory mineFieldFactory,
                                [NotNull] Func <IMineField, IMineLayer> mineLayerFactory,
                                [NotNull] Func <IMineField, IHintField> hintFieldFactory,
                                [NotNull] Func <IMineField, IPlayingField> playingFieldFactory,
                                [NotNull] IUserInput userInput,
                                [NotNull] Func <IHintField, IPlayingField, IUserOutput> userOutputFactory)
        {
            m_Converter = converter;
            m_MineFieldFactory = mineFieldFactory;
            m_MineLayerFactory = mineLayerFactory;
            m_HintFieldFactory = hintFieldFactory;
            m_PlayingFieldFactory = playingFieldFactory;
            m_UserInput = userInput;
            m_UserOutputFactory = userOutputFactory;
        }

        public int ColumnsCount
        {
            get
            {
                return m_MineField.ColumnsCount;
            }
        }

        private readonly IStringToMineFieldConverter m_Converter;
        private readonly Func <IMineField, IHintField> m_HintFieldFactory;
        private readonly MineField.Factory m_MineFieldFactory;
        private readonly Func <IMineField, IMineLayer> m_MineLayerFactory;
        private readonly Func <IMineField, IPlayingField> m_PlayingFieldFactory;
        private readonly IUserInput m_UserInput;
        private readonly Func <IHintField, IPlayingField, IUserOutput> m_UserOutputFactory;

        private IMineField m_MineField;
        private IPlayingField m_PlayingField;
        private IUserOutput m_UserOutput;

        public void CreateMineField(int numberOfRows,
                                    int numberOfColumns,
                                    int numberOfMines)
        {
            m_MineField = m_MineFieldFactory(numberOfRows,
                                             numberOfColumns);

            IMineLayer mineLayer = m_MineLayerFactory(m_MineField);
            mineLayer.PutMinesAtRandomLocation(numberOfMines);

            CreateCommon();
        }

        public void CreateMineField(string text)
        {
            m_MineField = m_Converter.ToMineField(text);

            CreateCommon();
        }

        public GameStatus.Player Status
        {
            get
            {
                return m_PlayingField.Status;
            }
        }

        public int RowsCount
        {
            get
            {
                return m_MineField.RowsCount;
            }
        }

        public int ColumsCount
        {
            get
            {
                return m_MineField.ColumnsCount;
            }
        }

        public IHintField HintField { get; private set; }

        public Tuple <int, int> AskUserForRowAndCoumn(int maximumNumberOfRows,
                                                      int maximumNumberOfColumns)
        {
            return m_UserInput.AskUserForRowAndCoumn(maximumNumberOfRows,
                                                     maximumNumberOfColumns);
        }

        public void DisplayPlayingField()
        {
            m_UserOutput.DisplayPlayingField();
        }

        public void UserSelectedField(int row,
                                      int column)
        {
            m_PlayingField.SelectField(row,
                                       column);
        }

        public int GetHintFor(int row,
                              int column)
        {
            return HintField.GetHintFor(row,
                                        column);
        }

        private void CreateCommon()
        {
            HintField = m_HintFieldFactory(m_MineField); // todo test setting field

            m_PlayingField = m_PlayingFieldFactory(m_MineField);

            m_UserOutput = m_UserOutputFactory(HintField,
                                               m_PlayingField);
        }
    }
}
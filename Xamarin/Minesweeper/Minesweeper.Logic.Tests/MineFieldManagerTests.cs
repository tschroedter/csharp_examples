using System;
using System.Diagnostics.CodeAnalysis;
using Minesweeper.Logic.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Minesweeper.Logic.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MineFieldManagerTests
    {
        [SetUp]
        public void Setup()
        {
            m_MineFieldFactory = MineFieldFactory;
            m_Converter = Substitute.For <IStringToMineFieldConverter>();
            m_MineField = Substitute.For <IMineField>();
            m_MineLayer = Substitute.For <IMineLayer>();
            m_HintField = Substitute.For <IHintField>();
            m_PlayingField = Substitute.For <IPlayingField>();
            m_UserOutput = Substitute.For <IUserOutput>();

            m_MineLayerFactory = MineLayerFactory;
            m_HintFieldFactory = HintFieldFactory;
            m_PlayingFieldFactory = PlayingFieldFactory;
            m_UserInptut = Substitute.For <IUserInput>();
            m_UserOutputFactory = UserOutputFactory;
        }

        private MineField.Factory m_MineFieldFactory;
        private IUserInput m_UserInptut;
        private IMineLayer m_MineLayer;
        private IHintField m_HintField;
        private IPlayingField m_PlayingField;
        private IUserOutput m_UserOutput;
        private IMineField m_MineField;
        private IStringToMineFieldConverter m_Converter;
        private Func <IMineField, IMineLayer> m_MineLayerFactory;
        private Func <IMineField, IHintField> m_HintFieldFactory;
        private Func <IMineField, IPlayingField> m_PlayingFieldFactory;
        private Func <IHintField, IPlayingField, IUserOutput> m_UserOutputFactory;

        private IMineField MineFieldFactory(
            int numberOfRows,
            int numberOfColumns)
        {
            return m_MineField;
        }

        private IMineLayer MineLayerFactory(
            IMineField hintField)
        {
            return m_MineLayer;
        }

        private IHintField HintFieldFactory(
            IMineField mineField)
        {
            return m_HintField;
        }

        private IPlayingField PlayingFieldFactory(
            IMineField mineField)
        {
            return m_PlayingField;
        }

        private IUserOutput UserOutputFactory(
            IHintField hintField,
            IPlayingField playingField)
        {
            return m_UserOutput;
        }

        private MineFieldManager CreateSut()
        {
            // todo remove long list of dependencies
            var sut = new MineFieldManager(m_Converter,
                                           m_MineFieldFactory,
                                           m_MineLayerFactory,
                                           m_HintFieldFactory,
                                           m_PlayingFieldFactory,
                                           m_UserInptut,
                                           m_UserOutputFactory);

            return sut;
        }

        [Test]
        public void AskUserForRowAndCoumn_CallsUserInput_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.AskUserForRowAndCoumn(1,
                                      2);

            // Assert
            m_UserInptut.Received().AskUserForRowAndCoumn(1,
                                                          2);
        }

        [Test]
        public void ColumnsCount_ReturnsCOunt_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            m_MineField.ColumnsCount.Returns(1);

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            Assert.AreEqual(1,
                            sut.ColumsCount);
        }

        [Test]
        public void CreateMineField_CallsConverter_ForGivenText()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField("Doesn't matter!");

            // Assert
            m_Converter.Received().ToMineField("Doesn't matter!");
        }

        [Test]
        public void CreateMineField_CreatesMineField_ForGivenText()
        {
            // Arrange
            var mineField = Substitute.For <IMineField>();
            mineField.RowsCount.Returns(1);
            mineField.ColumnsCount.Returns(2);
            m_Converter.ToMineField(Arg.Any <string>()).Returns(mineField);
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField("Doesn't matter!");

            // Assert
            Assert.AreEqual(1,
                            mineField.RowsCount,
                            "RowsCount");
            Assert.AreEqual(2,
                            mineField.ColumnsCount,
                            "ColumnsCount");
        }

        [Test]
        public void CreateMineField_PutMinesAtRandomLocation_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_MineLayer.Received().PutMinesAtRandomLocation(3);
        }

        [Test]
        public void DisplayPlayingField_CallsUserOutput_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);

            // Act
            sut.DisplayPlayingField();

            // Assert
            m_UserOutput.Received().DisplayPlayingField();
        }

        [Test]
        public void GetHintFor_ReturnsHint_ForRowAndColumn()
        {
            // Arrange
            m_HintField.GetHintFor(Arg.Any <int>(),
                                   Arg.Any <int>()).Returns(1);

            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);

            // Act
            int actual = sut.GetHintFor(1,
                                        2);

            // Assert
            Assert.AreEqual(1,
                            actual);
        }

        [Test]
        public void RowsCount_ReturnsCOunt_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            m_MineField.RowsCount.Returns(1);

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            Assert.AreEqual(1,
                            sut.RowsCount);
        }

        [Test]
        public void UserSelectedField_CallsPlayingField_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);

            // Act
            sut.UserSelectedField(1,
                                  2);

            // Assert
            m_PlayingField.Received().SelectField(1,
                                                  2);
        }

        [Test]
        public void UserSelectedField_UpdatesStatus_WhenPlayerSelectedMine()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);
            m_MineField.IsMineAt(1,
                                 2).Returns(true);

            // Act
            sut.UserSelectedField(1,
                                  2);

            // Assert
            Assert.AreEqual(GameStatus.Player.SelectedFieldWithMine,
                            sut.Status);
        }
    }
}
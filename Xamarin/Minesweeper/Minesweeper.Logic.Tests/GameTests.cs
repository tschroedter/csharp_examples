using System;
using System.Diagnostics.CodeAnalysis;
using Minesweeper.Logic.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Minesweeper.Logic.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class GameTests : TestFixtureBase <Game>
    {
        protected override void FreezeDependency()
        {
            Fixture.Freeze <IConsole>();
            Fixture.Freeze <IMineFieldManager>();
        }

        [Test]
        public void ColumnsCount_ReturnsCount_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.ColumsCount.Returns(2);

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            Assert.AreEqual(2,
                            Sut.ColumnsCount);
        }

        [Test]
        public void GameStatusToString_ReturnString_ForHasWone()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            string actual = Sut.GameStatusToString(GameStatus.Player.HasWon);

            // Assert
            Assert.AreEqual("You won!",
                            actual);
        }

        [Test]
        public void GameStatusToString_ReturnString_ForSelectedFieldWithMine()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            string actual = Sut.GameStatusToString(GameStatus.Player.SelectedFieldWithMine);

            // Assert
            Assert.AreEqual("You hit a mine!",
                            actual);
        }

        [Test]
        public void GameStatusToString_ReturnString_ForSelectedFieldWithoutMine()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            string actual = Sut.GameStatusToString(GameStatus.Player.SelectedFieldWithoutMine);

            // Assert
            Assert.AreEqual("Selected Field Without Mine!",
                            actual);
        }

        [Test]
        public void GetHintFor_CallsManager_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            int actual = Sut.GetHintFor(1,
                                        2);

            // Assert
            manager.Received().GetHintFor(1,
                                          2);
        }

        [Test]
        public void Initialize_CallsCreateMineField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            manager.Received().CreateMineField(1,
                                               2,
                                               3);
        }

        [Test]
        public void Initialize_CallsDisplayPlayingField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            manager.Received().DisplayPlayingField();
        }

        [Test]
        public void IsGameFinished_DisplayMessagePlayerWon_ForHasWon()
        {
            // Arrange
            var console = Fixture.Create <IConsole>();

            // Act
            Sut.IsGameFinished(GameStatus.Player.HasWon);

            // Assert
            console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void IsGameFinished_DisplayMessagePlayerWon_ForPlayerSelectedMine()
        {
            // Arrange
            var console = Fixture.Create <IConsole>();

            // Act
            Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithMine);

            // Assert
            console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void IsGameFinished_DisplayMessagePlayerWon_ForPlayerSelectedWithoutMine()
        {
            // Arrange
            var console = Fixture.Create <IConsole>();

            // Act
            Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithoutMine);

            // Assert
            console.DidNotReceive().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void IsGameFinished_ReturnsFalse_ForPlayerSelectedFieldWithoutMine()
        {
            // Arrange
            // Act
            // Assert
            Assert.False(Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithoutMine));
        }

        [Test]
        public void IsGameFinished_ReturnsTrue_ForPlayerHasWon()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(Sut.IsGameFinished(GameStatus.Player.HasWon));
        }

        [Test]
        public void IsGameFinished_ReturnsTrue_ForPlayerSelectedMine()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithMine));
        }

        [Test]
        public void IsGameFinished_ReturnTrue_ForHasWone()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            // Assert
            Assert.True(Sut.IsGameFinished(GameStatus.Player.HasWon));
        }

        [Test]
        public void IsGameFinished_ReturnTrue_ForSelectedFieldWithMine()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            // Assert
            Assert.True(Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithMine));
        }

        [Test]
        public void IsGameFinished_ReturnTrue_ForSelectedFieldWithoutMine()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            // Assert
            Assert.False(Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithoutMine));
        }

        [Test]
        public void PlayOneRound_CallsIsGameFinished_WhenPlayerWon()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            // Assert
            Assert.True(Sut.PlayOneRound(0,
                                         0)); // indirect test
        }

        [Test]
        public void PlayOneRound_CallsPlayOneRound_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            Sut.PlayOneRound();

            // Assert
            manager.Received().UserSelectedField(1,
                                                 2);
        }

        [Test]
        public void PlayOneRound_CallsSelectsField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            Sut.PlayOneRound(1,
                             2);

            // Assert
            manager.Received().UserSelectedField(1,
                                                 2);
        }

        [Test]
        public void PlayOneRound_DisplaysField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            Sut.PlayOneRound(0,
                             0);

            // Assert
            manager.Received().DisplayPlayingField();
        }

        [Test]
        public void RowsCount_ReturnsCount_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.RowsCount.Returns(1);

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            Assert.AreEqual(1,
                            Sut.RowsCount);
        }

        [Test]
        public void Start_CallsPlayOneRound_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            Sut.Start();

            // Assert
            manager.Received().UserSelectedField(Arg.Any <int>(),
                                                 Arg.Any <int>()); // indirect test
        }

        [Test]
        public void Status_ReturnsCount_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.Status.Returns(GameStatus.Player.SelectedFieldWithoutMine);

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            Assert.AreEqual(GameStatus.Player.SelectedFieldWithoutMine,
                            Sut.Status);
        }
    }
}
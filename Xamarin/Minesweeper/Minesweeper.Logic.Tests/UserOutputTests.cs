using System;
using System.Diagnostics.CodeAnalysis;
using Minesweeper.Logic.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Minesweeper.Logic.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class UserOutputTests
    {
        [SetUp]
        public void Setup()
        {
            m_Console = Substitute.For <IConsole>();
            m_DisplayPlayingFieldFactory = DisplayPlayingFieldFactory;
            m_HintField = Substitute.For <IHintField>();
            m_PlayingField = Substitute.For <IPlayingField>();
            m_DisplayPlayingField = Substitute.For <IDisplayPlayingField>();
        }

        private IDisplayPlayingField DisplayPlayingFieldFactory(
            IHintField hintField,
            IPlayingField playingField)
        {
            return m_DisplayPlayingField;
        }

        private Func <IHintField, IPlayingField, IDisplayPlayingField> m_DisplayPlayingFieldFactory;
        private IHintField m_HintField;
        private IPlayingField m_PlayingField;
        private IConsole m_Console;
        private IDisplayPlayingField m_DisplayPlayingField;

        private IUserOutput CreateSut()
        {
            var sut = new UserOutput(m_Console,
                                     m_DisplayPlayingFieldFactory,
                                     m_HintField,
                                     m_PlayingField);

            return sut;
        }

        [Test]
        public void DisplayPlayingField_CallsConsole_WhenCalled()
        {
            // Arrange
            IUserOutput sut = CreateSut();

            // Act
            sut.DisplayPlayingField();

            // Assert
            m_Console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void DisplayPlayingField_CallsConsoleForTitle_WhenCalled()
        {
            // Arrange
            IUserOutput sut = CreateSut();

            // Act
            sut.DisplayPlayingField();

            // Assert
            m_Console.Received().WriteLine("Minefield:");
        }

        [Test]
        public void DisplayPlayingField_CallsDisplayPlayingFieldField_WhenCalled()
        {
            // Arrange
            IUserOutput sut = CreateSut();

            // Act
            sut.DisplayPlayingField();

            // Assert
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            m_DisplayPlayingField.Received().ToString();
        }
    }
}
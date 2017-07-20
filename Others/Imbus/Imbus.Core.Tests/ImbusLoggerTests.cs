using System;
using System.Diagnostics.CodeAnalysis;
using Autofac.Extras.NLog;
using Imbus.Core;
using Moq;
using NUnit.Framework;

namespace NCQRS.Common.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public sealed class ImbusLoggerTests
    {
        [SetUp]
        public void Setup()
        {
            m_MockLogger = new Mock <ILogger>();

            m_Sut = new ImbusLogger(m_MockLogger.Object);
        }

        private Mock <ILogger> m_MockLogger;
        private ImbusLogger m_Sut;

        [Test]
        public void Debug_Calls_Debug_WhenCalled()
        {
            // Arrange
            var message = "Text {0}";

            // Act
            m_Sut.Debug(message,
                        "Argument");

            // Assert
            m_MockLogger.Verify(m => m.Debug(message,
                                             It.IsAny <object[]>()),
                                Times.Once);
        }

        [Test]
        public void Error_Calls_Error_For_Exception()
        {
            // Arrange
            var exception = new Exception("Test");

            // Act
            m_Sut.Error(exception);

            // Assert
            m_MockLogger.Verify(m => m.Error(exception),
                                Times.Once);
        }

        [Test]
        public void Error_Calls_Error_For_Exception_With_Arguments()
        {
            // Arrange
            var exception = new Exception("Test");
            var message = "Text {0}";

            // Act
            m_Sut.Error(exception,
                        message,
                        "Argument");

            // Assert
            m_MockLogger.Verify(m => m.Error(message,
                                             It.IsAny <object[]>(),
                                             exception),
                                Times.Once);
        }

        [Test]
        public void Error_Calls_Error_When_Called()
        {
            // Arrange
            var message = "Text {0}";

            // Act
            m_Sut.Error(message,
                        "Argument");

            // Assert
            m_MockLogger.Verify(m => m.Error(message,
                                             It.IsAny <object[]>()),
                                Times.Once);
        }

        [Test]
        public void Info_Calls_Info_WhenCalled()
        {
            // Arrange
            var message = "Text {0}";

            // Act
            m_Sut.Info(message,
                       "Argument");

            // Assert
            m_MockLogger.Verify(m => m.Info(message,
                                            It.IsAny <object[]>()),
                                Times.Once);
        }
    }
}
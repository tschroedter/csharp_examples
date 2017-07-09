using System;
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Common;
using NLog;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests.Common
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SuperMarketRegisterLoggerTests
    {
        [SetUp]
        public void Setup()
        {
            var mocker = new NSubstituteAutoMocker <SuperMarketRegisterLogger>();

            m_Logger = mocker.Get <ILogger>();

            m_Sut = mocker.ClassUnderTest;
        }

        private ILogger m_Logger;
        private SuperMarketRegisterLogger m_Sut;

        [Test]
        public void Error_Calls_Logger_For_Exception_And_Message()
        {
            // Arrange
            var exception = new Exception("Test");
            const string message = "Test";

            // Act
            m_Sut.Error(message,
                        exception);

            // Assert
            m_Logger.Received().Error(exception,
                                      message);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Asl.Puzzles.SuperMarketRegister.Aop;
using Asl.Puzzles.SuperMarketRegister.Interfaces.Aop;
using Castle.DynamicProxy;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Asl.Puzzles.SuperMarketRegister.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class AddItemAspectTests
    {
        [SetUp]
        public void Setup()
        {
            m_Info = Substitute.For <MethodInfo>();
            m_Invocation = Substitute.For <IInvocation>();
            m_Invocation.Method.Returns(m_Info);

            var mocker = new NSubstituteAutoMocker <AddItemAspect>();
            m_Validtor = mocker.Get <IAddItemArgumentsValidator>();

            m_Sut = mocker.ClassUnderTest;
        }

        private AddItemAspect m_Sut;
        private IAddItemArgumentsValidator m_Validtor;
        private IInvocation m_Invocation;
        private MethodInfo m_Info;

        [Test]
        public void Intercept_Calls_Proceed()
        {
            // Arrange
            // Act
            m_Sut.Intercept(m_Invocation);

            // Assert
            m_Invocation.Received().Proceed();
        }

        [Test]
        public void Intercept_Calls_Validate_For_AddItem_Method()
        {
            // Arrange
            m_Info.Name.Returns("AddItem");

            var args = new object[0];
            m_Invocation.Arguments.Returns(args);

            // Act
            m_Sut.Intercept(m_Invocation);

            // Assert
            m_Validtor.Received().Validate(args);
        }

        [Test]
        public void Intercept_Does_Not_Call_Validate_For_Other_Methods()
        {
            // Arrange
            m_Info.Name.Returns("AddItem");

            var args = new object[0];
            m_Invocation.Arguments.Returns(args);

            // Act
            m_Sut.Intercept(m_Invocation);

            // Assert
            m_Validtor.Received().Validate(args);
        }
    }
}
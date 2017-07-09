using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Interfaces;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PuzzleTests
    {
        [SetUp]
        public void Setup()
        {
            var mocker = new NSubstituteAutoMocker <Puzzle>();
            m_Engine = mocker.Get <IRulesEngine>();

            m_Sut = mocker.ClassUnderTest;
        }

        private Puzzle m_Sut;
        private IRulesEngine m_Engine;

        private const int DoesNotMatter = 1;

        [Test]
        public void FizzBuzz_Calls_Engine()
        {
            // Arrange
            m_Engine.Apply(Arg.Any <int>()).Returns("Test");

            // Act
            string actual = m_Sut.FizzBuzz(DoesNotMatter);

            // Assert
            Assert.AreEqual("Test",
                            actual);
        }
    }
}
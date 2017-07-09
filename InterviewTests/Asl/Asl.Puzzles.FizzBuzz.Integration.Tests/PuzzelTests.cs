using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Interfaces;
using Autofac;
using NUnit.Framework;

namespace Asl.Puzzles.FizzBuzz.Integration.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class PuzzelTests
    {
        [SetUp]
        public void Setup()
        {
            IContainer container = CreateContainer();

            m_Sut = container.Resolve <IPuzzle>();
        }

        private IPuzzle m_Sut;

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(9, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(11, "11")]
        [TestCase(12, "Fizz")]
        [TestCase(13, "13")]
        [TestCase(14, "14")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(16, "16")]
        public void FizzBuzzeturns_Text(
            int number,
            string expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(expected,
                            m_Sut.FizzBuzz(number));
        }

        private IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule <FizzBuzzModule>();
            IContainer container = builder.Build();

            return container;
        }
    }
}
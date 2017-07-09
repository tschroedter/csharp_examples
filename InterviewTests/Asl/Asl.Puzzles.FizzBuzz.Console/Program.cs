using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.FizzBuzz.Interfaces;
using Autofac;
using static System.Console;

namespace Asl.Puzzles.FizzBuzz.Console
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main()
        {
            IContainer container = CreateContainer();

            var puzzle = container.Resolve <IPuzzle>();

            for ( var i = 1 ; i <= 100 ; i++ )
            {
                WriteLine("{0:D3}, \"{1}\"",
                          i,
                          puzzle.FizzBuzz(i));
            }

            WriteLine("Press a key to continue...");
            ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule <FizzBuzzModule>();
            IContainer container = builder.Build();

            return container;
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using Asl.Puzzles.SuperMarketRegister.Common;
using Asl.Puzzles.SuperMarketRegister.Interfaces;
using Autofac;
using static System.Console;

namespace Asl.Puzzles.SuperMarketRegister.Console
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main()
        {
            IContainer container = CreateContainer();

            var receipt = container.Resolve <IReceipt>();
            receipt.AddItem(1,
                            "Candy Bar",
                            0.50);
            receipt.AddItem(2,
                            "Soda",
                            1);

            WriteLine(receipt.ToString());

            ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule <LoggingModule>();
            builder.RegisterModule <SuperMarketRegisterModule>();

            IContainer container = builder.Build();

            return container;
        }
    }
}
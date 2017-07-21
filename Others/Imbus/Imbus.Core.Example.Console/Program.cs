using System;
using Autofac;
using Autofac.Core;
using Autofac.Extras.NLog;
using Imbus.Core.Autofac;
using Imbus.Core.Example.Autofac;
using Imbus.Core.Example.Handlers;
using Imbus.Core.Example.Interfaces;
using Imbus.Core.Example.Interfaces.Buses;
using Imbus.Core.Interfaces;
using JetBrains.Annotations;
using static System.Console;

namespace Imbus.Core.Example.Console
{
    public static class Program
    {
        private static readonly int NumberOfHandlers = 100;
        private static readonly int NumberOfMessages = 10;

        [UsedImplicitly]
        private static TestMessageHandler[] s_Handlers;

        private static MessageBusTester s_TesterOne;
        private static MessageBusTester s_TesterTwo;

        public static void Main()
        {
            IContainer container = CreateContainer();

            var logger = container.Resolve <IImbusLogger>();

            try
            {
                var firstBus = container.Resolve <IFirstBus>();
                var secondBus = container.Resolve <ISecondBus>();

                s_TesterOne = CreateTester(container,
                                           firstBus);

                s_TesterTwo = CreateTester(container,
                                           secondBus);

                s_TesterOne.NumberOfHandlers = NumberOfHandlers;
                s_TesterOne.NumberOfMessages = NumberOfMessages;
                s_TesterOne.Initialize();

                s_TesterTwo.NumberOfHandlers = NumberOfHandlers;
                s_TesterTwo.NumberOfMessages = NumberOfMessages;
                s_TesterTwo.Initialize();

                s_TesterOne.Run();
                s_TesterTwo.Run();
            }
            catch ( Exception exception )
            {
                logger.Error(exception);
            }

            WriteLine("Press key to continue...");
            ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule <NLogModule>();
            builder.RegisterModule <SimpleNLogModule>();
            builder.RegisterModule <ImbusCoreAutofacModule>();
            builder.RegisterModule <ImbusCoreExampleModule>();

            IContainer container = builder.Build();

            return container;
        }

        private static MessageBusTester CreateTester(
            [NotNull] IContainer container,
            [NotNull] IMessageBus bus)
        {
            var one = new NamedParameter("container",
                                         container);
            var two = new NamedParameter("bus",
                                         bus);

            Parameter[] parameters =
            {
                one,
                two
            };

            var tester = container.Resolve <MessageBusTester>(parameters);

            return tester;
        }
    }
}
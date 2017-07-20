using Imbus.Core.Example.Messages;
using JetBrains.Annotations;
using static System.Console;

namespace Imbus.Core.Example.Handlers
{
    [UsedImplicitly]
    public class FinishedMessageHandler
        : BaseMessageHandler <FinishedMessage>
    {
        public FinishedMessageHandler()
            : base("FinishedHandler")
        {
        }

        protected override void HandleMessage(FinishedMessage message)
        {
            WriteLine($"[{message.BusName}] {message.SubscriptionId} has finished!");
        }
    }
}
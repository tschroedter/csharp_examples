using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GamesReviews.Console.Client;
using GamesReviews.Console.Server;
using static System.Console;

namespace GamesReviews.Console
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main()
        {
            var server = new RunServer();
            Task.Factory.StartNew(server.Run);

            var client = new RunClient();
            Task.Factory.StartNew(client.Run);

            WriteLine("Press any [Enter] to close the host.");
            ReadLine();
        }
    }
}
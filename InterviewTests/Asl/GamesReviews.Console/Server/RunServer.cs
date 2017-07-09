using System;
using Nancy.Hosting.Self;

namespace GamesReviews.Console.Server
{
    public class RunServer : IDisposable
    {
        private readonly NancyHost m_Host;
        private readonly Uri m_Uri;

        public RunServer()
        {
            m_Uri =
                new Uri("http://localhost:63579");

            var bootstrapper = new Bootstrapper();

            m_Host = new NancyHost(m_Uri,
                                   bootstrapper);
        }

        public void Dispose()
        {
            m_Host.Stop();
            m_Host.Dispose();
        }

        public void Run()
        {
            System.Console.WriteLine("Starting server...");

            m_Host.Start();

            System.Console.WriteLine("Your application is running on " + m_Uri);
        }
    }
}
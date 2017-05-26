using System;
using Android.Util;
using Minesweeper.Logic.Ioc;

namespace Minesweeper.Logic
{
    // todo can't use [ExcludeFromCodeCoverage]
    public class MinesweeperLogger
        : ILogger
    {
        public const string Tag = "MinesweeperLogger";

        public void Debug(string message)

        {
            Log.Debug(Tag,
                      message);
        }

        public void Debug(string message,
                          Exception exception)
        {
            Log.Debug(Tag,
                      message);
            Log.Debug(Tag,
                      exception.ToString());
        }

        public void Debug(string format,
                          params object[] args)
        {
            Log.Debug(Tag,
                      format,
                      args);
        }

        public void Error(string message)
        {
            Log.Error(Tag,
                      message);
        }

        public void Error(string message,
                          Exception exception)
        {
            Log.Error(Tag,
                      message);
            Log.Error(Tag,
                      exception.ToString());
        }

        public void Error(string format,
                          params object[] args)
        {
            Log.Error(Tag,
                      format,
                      args);
        }

        public void Fatal(string message)
        {
            Error(message);
        }

        public void Fatal(string message,
                          Exception exception)
        {
            Error(message,
                  exception);
        }

        public void Fatal(string format,
                          params object[] args)
        {
            Error(format,
                  args);
        }

        public void Info(string message)
        {
            Log.Info(Tag,
                     message);
        }

        public void Info(string message,
                         Exception exception)
        {
            Log.Info(Tag,
                     message);
            Log.Info(Tag,
                     exception.ToString());
        }

        public void Info(string format,
                         params object[] args)
        {
            Log.Info(Tag,
                     format,
                     args);
        }

        public void Warn(string message)
        {
            Log.Warn(Tag,
                     message);
        }

        public void Warn(string message,
                         Exception exception)
        {
            Log.Warn(Tag,
                     message);
            Log.Warn(Tag,
                     exception.ToString());
        }

        public void Warn(string format,
                         params object[] args)
        {
            Log.Warn(Tag,
                     format,
                     args);
        }
    }
}
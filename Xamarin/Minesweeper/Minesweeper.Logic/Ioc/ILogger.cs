﻿using System;

namespace Minesweeper.Logic.Ioc
{
    public interface ILogger // todo
    {
        void Debug(string message);

        void Debug(string message,
                   Exception exception);

        void Debug(string format,
                   params object[] args);

        void Error(string message);

        void Error(string message,
                   Exception exception);

        void Error(string format,
                   params object[] args);

        void Fatal(string message);

        void Fatal(string message,
                   Exception exception);

        void Fatal(string format,
                   params object[] args);

        void Info(string message);

        void Info(string message,
                  Exception exception);

        void Info(string format,
                  params object[] args);

        void Warn(string message);

        void Warn(string message,
                  Exception exception);

        void Warn(string format,
                  params object[] args);
    }
}
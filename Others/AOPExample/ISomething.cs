﻿using System;

namespace AOPExample
{
    public interface ISomething
    {
        int Augment(Int32 input);
        void DoSomething(String input);
        int Property
        {
            get;
            set;
        }
    }
}
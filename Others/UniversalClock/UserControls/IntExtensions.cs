using System;

namespace UserControls
{
    public static class IntExtensions
    {
        public static TimeSpan Seconds(this int seconds)
        {
            return new TimeSpan(0,
                                0,
                                0,
                                0,
                                seconds);
        }
    }
}
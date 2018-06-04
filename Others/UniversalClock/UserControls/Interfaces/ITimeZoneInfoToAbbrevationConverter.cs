using System;
using JetBrains.Annotations;

namespace UserControls.Interfaces
{
    public interface ITimeZoneInfoToAbbrevationConverter
    {
        [NotNull]
        TimeZoneInfo TimeZoneInfo { get; set; }

        [NotNull]
        string Abbrevation { get; set; }

        void Convert();
    }
}
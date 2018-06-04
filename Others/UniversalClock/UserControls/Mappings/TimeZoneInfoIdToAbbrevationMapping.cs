using System;
using JetBrains.Annotations;
using UserControls.Interfaces;

namespace UserControls.Mappings
{
    public class TimeZoneInfoIdToAbbrevationMapping : ITimeZoneInfoIdToAbbrevationMapping
    {
        public TimeZoneInfoIdToAbbrevationMapping(
            [NotNull] string id,
            bool             isDaylightSavingTime,
            [NotNull] string abbrevation)
        {
            Id                   = id ?? throw new ArgumentNullException(nameof(id));
            IsDaylightSavingTime = isDaylightSavingTime;
            Abbrevation          = abbrevation ?? throw new ArgumentNullException(nameof(abbrevation));
        }

        public string Id { get; }

        public bool IsDaylightSavingTime { get; }

        public string Abbrevation { get; }
    }
}
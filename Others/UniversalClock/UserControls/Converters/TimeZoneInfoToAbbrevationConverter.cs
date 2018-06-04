using System;
using JetBrains.Annotations;
using UserControls.Interfaces;

namespace UserControls.Converters
{
    public class TimeZoneInfoToAbbrevationConverter : ITimeZoneInfoToAbbrevationConverter
    {
        public TimeZoneInfoToAbbrevationConverter([NotNull] ITimeZoneInfoIdToAbbrevationMappings mappings)
        {
            m_Mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));
        }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;


        [NotNull]
        private readonly ITimeZoneInfoIdToAbbrevationMappings m_Mappings;

        public TimeZoneInfo TimeZoneInfo { get; set; } = TimeZoneInfo.Utc;
        public string       Abbrevation  { get; set; } = string.Empty;

        public void Convert()
        {
            m_Mappings.TryGetValue(TimeZoneInfo.Id,
                                   TimeZoneInfo.IsDaylightSavingTime(DateTime),
                                   out string abbrevation);

            Abbrevation = abbrevation;
        }
    }
}
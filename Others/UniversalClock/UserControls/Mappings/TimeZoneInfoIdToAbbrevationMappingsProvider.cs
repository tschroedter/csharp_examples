using System.Collections.Generic;
using UserControls.Interfaces;

namespace UserControls.Mappings
{
    public class TimeZoneInfoIdToAbbrevationMappingsProvider : ITimeZoneInfoIdToAbbrevationMappingsProvider
    {
        private readonly List <ITimeZoneInfoIdToAbbrevationMapping> m_Mappings =
            new List <ITimeZoneInfoIdToAbbrevationMapping>();

        public TimeZoneInfoIdToAbbrevationMappingsProvider()
        {
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("UTC",
                                                                  false,
                                                                  "UTC"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("UTC",
                                                                  true,
                                                                  "UTC"));

            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("Cen. Australia Standard Time",
                                                                  false,
                                                                  "CST"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("Cen. Australia Standard Time",
                                                                  true,
                                                                  "CDT"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("E. Australia Standard Time",
                                                                  false,
                                                                  "EST"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("E. Australia Standard Time",
                                                                  true,
                                                                  "EDT"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("W. Australia Standard Time",
                                                                  false,
                                                                  "WST"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("W. Australia Standard Time",
                                                                  true,
                                                                  "WST"));

            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("AUS Central Standard Time",
                                                                  false,
                                                                  "ACST"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("AUS Central Standard Time",
                                                                  true,
                                                                  "ACDT"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("AUS Eastern Standard Time",
                                                                  false,
                                                                  "AEST"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("AUS Eastern Standard Time",
                                                                  true,
                                                                  "AEDT"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("AUS Western Standard Time",
                                                                  false,
                                                                  "AWST"));
            m_Mappings.Add(new TimeZoneInfoIdToAbbrevationMapping("AUS Western Standard Time",
                                                                  true,
                                                                  "AWST"));
        }

        public IEnumerable <ITimeZoneInfoIdToAbbrevationMapping> Mappings => m_Mappings;
    }
}
using System.Collections.Generic;

namespace UserControls.Interfaces
{
    public interface ITimeZoneInfoIdToAbbrevationMappingsProvider
    {
        IEnumerable <ITimeZoneInfoIdToAbbrevationMapping> Mappings { get; }
    }
}
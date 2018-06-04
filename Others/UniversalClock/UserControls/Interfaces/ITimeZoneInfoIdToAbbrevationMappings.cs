using JetBrains.Annotations;

namespace UserControls.Interfaces
{
    public interface ITimeZoneInfoIdToAbbrevationMappings
    {
        bool TryGetValue([NotNull] string id,
                         bool             isDaylightSavingTime,
                         out string       abbrevation);
    }
}
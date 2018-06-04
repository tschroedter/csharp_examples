using JetBrains.Annotations;

namespace UserControls.Interfaces
{
    public interface ITimeZoneInfoIdToAbbrevationMapping
    {
        [NotNull]
        string Id { get; }
        bool IsDaylightSavingTime { get; }
        [NotNull]
        string Abbrevation { get; }
    }
}
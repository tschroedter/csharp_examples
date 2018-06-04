using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UserControls.Interfaces;

namespace UserControls.Mappings
{
    public class TimeZoneInfoIdToAbbrevationMappings : ITimeZoneInfoIdToAbbrevationMappings
    {
        public TimeZoneInfoIdToAbbrevationMappings([NotNull] ITimeZoneInfoIdToAbbrevationMappingsProvider provider)
        {
            foreach ( ITimeZoneInfoIdToAbbrevationMapping mapping in provider.Mappings )
            {
                m_Dictionary.Add(new Key(mapping.Id,
                                         mapping.IsDaylightSavingTime),
                                 mapping.Abbrevation);
            }
        }

        private readonly Dictionary <Key, string> m_Dictionary = new Dictionary <Key, string>();

        public bool TryGetValue(string     id,
                                bool       isDaylightSavingTime,
                                out string abbrevation)
        {
            bool sucess = m_Dictionary.TryGetValue(new Key(id,
                                                           isDaylightSavingTime),
                                                   out string result);

            abbrevation = sucess
                              ? result
                              : string.Empty;

            return sucess;
        }

        private class Key
        {
            private bool Equals(Key other)
            {
                return string.Equals(Id,
                                     other.Id) && IsDaylightSavingTime == other.IsDaylightSavingTime;
            }

            public override bool Equals(object obj)
            {
                if ( ReferenceEquals(null,
                                     obj) )
                {
                    return false;
                }

                if ( ReferenceEquals(this,
                                     obj) )
                {
                    return true;
                }

                if ( obj.GetType() != GetType() )
                {
                    return false;
                }

                return Equals(( Key ) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ( ( Id != null
                                   ? Id.GetHashCode()
                                   : 0 ) * 397 ) ^ IsDaylightSavingTime.GetHashCode();
                }
            }

            public Key([NotNull] string id,
                       bool             isDaylightSavingTime)
            {
                Id                   = id ?? throw new ArgumentNullException(nameof(id));
                IsDaylightSavingTime = isDaylightSavingTime;
            }

            [UsedImplicitly]
            public string Id                   { get; }

            [UsedImplicitly]
            public bool   IsDaylightSavingTime { get; }
        }
    }
}
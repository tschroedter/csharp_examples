using System;
using System.Globalization;
using System.Windows.Data;
using JetBrains.Annotations;
using UserControls.Interfaces;
using UserControls.Mappings;

namespace UserControls.Converters
{
    internal class TimeZoneInfoValueConverter : IValueConverter
    {
        public TimeZoneInfoValueConverter()
            : this(new
                       TimeZoneInfoToAbbrevationConverter(new
                                                              TimeZoneInfoIdToAbbrevationMappings(new
                                                                                                      TimeZoneInfoIdToAbbrevationMappingsProvider())))
        {
        }

        public TimeZoneInfoValueConverter([NotNull] ITimeZoneInfoToAbbrevationConverter converter)
        {
            m_Converter = converter;
        }

        private readonly ITimeZoneInfoToAbbrevationConverter m_Converter;

        public object Convert(object      value,
                              Type        targetType,
                              object      parameter,
                              CultureInfo culture)
        {
            if ( !( value is TimeZoneInfo timeZoneInfo ) )
            {
                return string.Empty;
            }

            m_Converter.TimeZoneInfo = timeZoneInfo;
            m_Converter.Convert();

            string result = " " + m_Converter.Abbrevation + " ";

            return result;
        }

        public object ConvertBack(object      value,
                                  Type        targetType,
                                  object      parameter,
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
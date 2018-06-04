using System;
using System.Globalization;
using System.Windows.Data;

namespace UserControls.Converters
{
    internal class DateTimeMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[]    values,
                              Type        targetType,
                              object      parameter,
                              CultureInfo culture)
        {
            if (values.Length != 2)
            {
                return string.Empty;
            }

            if (!(values[0] is DateTime dateTime) ||
                !(values[1] is string dateFormat))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(dateFormat))
                return string.Empty;

            string result = dateTime.ToString(dateFormat);
            result += " ";

            return result;
        }

        public object[] ConvertBack(object      value,
                                    Type[]      targetTypes,
                                    object      parameter,
                                    CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Controls
{
    public class UniformScaleMatrixMultiValueConverter
    : IMultiValueConverter
    {
        public object Convert(object[]    values,
                              Type        targetType,
                              object      parameter,
                              CultureInfo culture)
        {
            if ( values.Length != 3 )
                return Binding.DoNothing;

            if ( !( values [ 0 ] is double scale ) )
                return Binding.DoNothing;

            if ( !( values [ 1 ] is double width ) )
                return Binding.DoNothing;

            if ( !( values [ 2 ] is double height ) )
                return Binding.DoNothing;

            var matrix = new Matrix();

            matrix.ScaleAt(scale,
                           scale,
                           width  / 2.0,
                           height / 2.0);

            var transform = new MatrixTransform(matrix);

            return transform;
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
using System;
using System.IO;
using System.Windows.Media.Imaging;
using JetBrains.Annotations;

namespace Controls
{
    public class BitmapSourceToPngStreamConverter
        : IBitmapSourceToPngStreamConverter
    {
        public Stream ToStream(BitmapSource bitmapSource)
        {
            Stream stream = new MemoryStream();

            try
            {
                var encoder = new PngBitmapEncoder();

                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);
            }
            catch ( Exception )
            {
                // todo log error
            }

            return stream;
        }
    }

    public interface IBitmapSourceToPngStreamConverter
    {
        [NotNull]
        Stream ToStream([NotNull] BitmapSource bitmapSource);
    }
}
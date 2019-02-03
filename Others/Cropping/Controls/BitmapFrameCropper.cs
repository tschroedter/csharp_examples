using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JetBrains.Annotations;

namespace Controls
{
    public class BitmapFrameCropper
        : IBitmapFrameCropper
    {
        private const double DefaultDpiX = 96d;
        private const double DefaultDpiY = 96d;

        // todo logger

        public BitmapFrame Crop(Panel     panel,
                                Int32Rect croppingArea)
        {
            // todo guard

            try
            {
                var rtb =
                    new RenderTargetBitmap(( int ) panel.RenderSize.Width,
                                           ( int ) panel.RenderSize.Height,
                                           DefaultDpiX,
                                           DefaultDpiY,
                                           PixelFormats.Pbgra32);

                rtb.Render(panel);

                var crop =
                    new CroppedBitmap(rtb,
                                      croppingArea);

                return BitmapFrame.Create(crop);
            }
            catch ( Exception )
            {
                // todo log
            }

            return null;
        }
    }

    public interface IBitmapFrameCropper
    {
        [CanBeNull]
        BitmapFrame Crop([NotNull] Panel panel,
                         Int32Rect       croppingArea);
    }
}
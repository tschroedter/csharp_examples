using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using JetBrains.Annotations;

namespace Controls
{
    public class ProfilePhotoViewModel
        : ViewModelBase
    {
        public ProfilePhotoViewModel()
        {
            ImageScale = 4.0;
            CroppingRect = new Rect(100.0,
                                    100.0,
                                    100.0,
                                    100.0);

            CropCommand         = new DelegateCommand(Crop);
            BorderLoadedCommand = new DelegateCommand<Border>(BorderLoaded);
            CanvasLoadedCommand = new DelegateCommand <Canvas>(CanvasLoaded);
            ImageLoadedCommand  = new DelegateCommand <Image>(ImageLoaded);
            LayoutUpdatedCommand = new DelegateCommand(LayoutUpdated);
        }

        public DelegateCommand <Border> BorderLoadedCommand { get; set; }

        public DelegateCommand <Image> ImageLoadedCommand { get; set; }

        public DelegateCommand <Canvas> CanvasLoadedCommand { get; set; }

        public DelegateCommand LayoutUpdatedCommand { get; set; }

        public DelegateCommand CropCommand { get; set; }

        public double ImageScale
        {
            get { return GetProperty(() => ImageScale); }
            set { SetProperty(() => ImageScale, value); }
        }

        public Rect CroppingRect
        {
            get { return GetProperty(() => CroppingRect); }
            set { SetProperty(() => CroppingRect, value); }
        }

        [CanBeNull]
        public Border ProfilePhotoBorder { get; set; }

        [CanBeNull]
        public Canvas ProfilePhotoCanvas { get; set; }

        [CanBeNull]
        public Image ProfilePhoto { get; set; }

        private void CanvasLoaded(Canvas canvas)
        {
            ProfilePhotoCanvas = canvas;
        }

        private void BorderLoaded(Border border)
        {
            ProfilePhotoBorder = border;
        }

        private void Crop()
        {
            throw new NotImplementedException();
        }

        private void LayoutUpdated()
        {
            // if ( ProfilePhoto       == null ||
            //      ProfilePhotoCanvas == null ||
            //      ProfilePhotoBorder == null )
            //     return;
            //
            // var bounds = ProfilePhoto.TransformToAncestor(ProfilePhotoBorder)
            //                          .TransformBounds(new Rect(ProfilePhoto
            //                                                       .RenderSize));
            //
            // var offset =
            //     new Point(Math.Round(CroppingRect.Left - bounds.TopLeft.X),
            //               Math.Round(CroppingRect.Top  - bounds.TopLeft.Y));
            //
            // var offsetVisual = new Point(Math.Round(offset.X * ImageScale),
            //                              Math.Round(offset.Y * ImageScale));
            //
            // var source = ProfilePhoto.Source as BitmapSource;
            //
            // if (source == null)
            //     return;
            //
            // var sourceWidthAt96Dpi = source.Width * source.DpiX / 96.0;
            // var sourceHeightAt96Dpi = source.Height * source.DpiY / 96.0;
            //
            // var scaleToRealX = sourceWidthAt96Dpi / bounds.Width;
            // var scaleToRealY = sourceHeightAt96Dpi / bounds.Height;
            //
            // var offsetReal = new Point(Math.Round(offset.X * scaleToRealX),
            //                            Math.Round(offset.Y * scaleToRealY));
            //
            // var vis = new DrawingVisual();
            // var dc  = vis.RenderOpen();
            // dc.DrawImage(ProfilePhoto.Source,
            //              new Rect
            //              {
            //                  Width  = sourceWidthAt96Dpi,
            //                  Height = sourceHeightAt96Dpi
            //              });
            // dc.Close();
            //
            // var rtb =
            //     new RenderTargetBitmap((int)sourceWidthAt96Dpi,
            //                            (int)sourceWidthAt96Dpi,
            //                            96d,
            //                            96d,
            //                            PixelFormats.Pbgra32);
            //
            // rtb.Render(vis);
            //
            // var crop =
            //     new CroppedBitmap(rtb,
            //                       new Int32Rect((int)offsetReal.X,
            //                                     (int)offsetReal.Y,
            //                                     (int)(400.0),
            //                                     (int)(400.0)));
            //
            // var cropped = BitmapFrame.Create(crop);
            //
            // var cc = new BitmapSourceToPngStreamConverter();
            //
            // using (var fileStream = File.Create(@"C:\Temp\cropped.png"))
            // {
            //     using (var stream = cc.ToStream(cropped))
            //     {
            //         stream.Seek(0, SeekOrigin.Begin);
            //         stream.CopyTo(fileStream);
            //     }
            // }
        }

        private void ImageLoaded(Image image)
        {
            ProfilePhoto = image;
        }
    }
}
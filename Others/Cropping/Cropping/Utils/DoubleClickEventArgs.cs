using System;
using System.Windows.Media.Imaging;

namespace Cropping.Utils
{
    public class DoubleClickEventArgs : EventArgs
    {
        public BitmapFrame BitmapFrame { get; set; }
    }
}
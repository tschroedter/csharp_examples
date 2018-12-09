using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Cropping;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Internal;

namespace CroppingApplication
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _profilePhotoCanvas = ProfilePhoto.Parent as Canvas;
        }

        private Canvas          _profilePhotoCanvas;
        private CroppingAdorner _croppingAdorner;

        private void OnClickTakePictureDialog(object          sender,
                                              RoutedEventArgs args)
        {
            string title = EditorLocalizer.GetString(EditorStringId
                                                        .CameraTakePictureCaption);

            var takePictureWindow = new DXWindow
                                    {
                                        Width     = 350,
                                        Height    = 350,
                                        MinHeight = 350,
                                        MinWidth  = 350,
                                        ShowIcon  = false,
                                        WindowStartupLocation =
                                            WindowStartupLocation.CenterOwner,
                                        Owner = this,
                                        Title = title
                                    };

            var takePicture = new TakePictureControl();

            PopupBaseEdit popup = PopupBaseEdit.GetPopupOwnerEdit(ProfilePhoto);

            takePicture.SetEditor(ProfilePhoto,
                                  popup as PopupImageEdit);
            takePictureWindow.Content = takePicture;
            takePictureWindow.ShowDialog();
        }

        private void OnClickOpenFileDialog(object          sender,
                                           RoutedEventArgs e)
        {
            ProfilePhoto.Load();
        }

        private void Window_Loaded(object          sender,
                                   RoutedEventArgs e)
        {
            AdornerLayer adornerLayer =
                AdornerLayer.GetAdornerLayer(CanvasPanel);
            _croppingAdorner = new CroppingAdorner(CanvasPanel);
            adornerLayer.Add(_croppingAdorner);
        }

        private void OnCropPicture(object          sender,
                                   RoutedEventArgs e)
        {
            ProfilePhoto.Source = _croppingAdorner.GetCroppedBitmapFrame();
        }
    }
}
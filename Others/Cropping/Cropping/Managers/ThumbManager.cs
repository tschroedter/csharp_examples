using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Cropping.Thumbs;

namespace Cropping.Managers
{
    /// <summary>
    ///     Class that represent for displaying/redraw thumbs
    /// </summary>
    internal class ThumbManager
    {
        public ThumbManager(Canvas           canvas,
                            RectangleManager rectangleManager)
        {
            //  initialize
            _canvas           = canvas;
            _rectangleManager = rectangleManager;
            _thumbSize        = 10;

            //  create thumbs with factory
            _bottomMiddle =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.BottomMiddle,
                                         _canvas,
                                         _thumbSize);

            _leftMiddle =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.LeftMiddle,
                                         _canvas,
                                         _thumbSize);

            _topMiddle =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.TopMiddle,
                                         _canvas,
                                         _thumbSize);

            _rightMiddle =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.RightMiddle,
                                         _canvas,
                                         _thumbSize);

            _topLeft =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.TopLeft,
                                         _canvas,
                                         _thumbSize);

            _topRight =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.TopRight,
                                         _canvas,
                                         _thumbSize);

            _bottomLeft =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.BottomLeft,
                                         _canvas,
                                         _thumbSize);

            _bottomRight =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.BottomRight,
                                         _canvas,
                                         _thumbSize);

            _center =
                ThumbFactory.CreateThumb(ThumbFactory.ThumbPosition.Center,
                                         _canvas,
                                         _thumbSize);

            //  subscribe to mouse events
            _bottomMiddle.DragDelta += BottomMiddleDragDeltaEventHandler;
            _bottomMiddle.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _bottomMiddle.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _leftMiddle.DragDelta += LeftMiddleDragDeltaEventHandler;
            _leftMiddle.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _leftMiddle.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _topMiddle.DragDelta += TopMiddleDragDeltaEventHandler;
            _topMiddle.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _topMiddle.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _rightMiddle.DragDelta += RightMiddleDragDeltaEventHandler;
            _rightMiddle.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _rightMiddle.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _topLeft.DragDelta += TopLeftDragDeltaEventHandler;
            _topLeft.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _topLeft.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _topRight.DragDelta += TopRightDragDeltaEventHandler;
            _topRight.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _topRight.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _bottomLeft.DragDelta += BottomLeftDragDeltaEventHandler;
            _bottomLeft.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _bottomLeft.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _bottomRight.DragDelta += BottomRightDragDeltaEventHandler;
            _bottomRight.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _bottomRight.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

            _center.DragDelta += CenterDragDeltaEventHandler;
            _center.PreviewMouseLeftButtonDown +=
                PreviewMouseLeftButtonDownGenericHandler;
            _center.PreviewMouseLeftButtonUp +=
                PreviewMouseLeftButtonUpGenericHandler;

        }

        private readonly ThumbCrop _bottomMiddle,
                                   _leftMiddle,
                                   _topMiddle,
                                   _rightMiddle,
                                   _topLeft,
                                   _topRight,
                                   _bottomLeft,
                                   _bottomRight,
                                   _center;

        private readonly Canvas           _canvas;
        private readonly RectangleManager _rectangleManager;
        private readonly double           _thumbSize;
        private bool _isDragging;
        private Point _mouseStartPoint;
        private Point _mouseLastPoint;

        /// <summary>
        ///     Manage thumbs visibility
        /// </summary>
        /// <param name="isVisible">Set current visibility</param>
        public void ShowThumbs(bool isVisible)
        {
            if ( isVisible &&
                 _rectangleManager.RectangleHeight > 0 &&
                 _rectangleManager.RectangleWidth  > 0 )
            {
                _bottomMiddle.Visibility = Visibility.Visible;
                _leftMiddle.Visibility   = Visibility.Visible;
                _topMiddle.Visibility    = Visibility.Visible;
                _rightMiddle.Visibility  = Visibility.Visible;
                _topLeft.Visibility      = Visibility.Visible;
                _topRight.Visibility     = Visibility.Visible;
                _bottomLeft.Visibility   = Visibility.Visible;
                _bottomRight.Visibility  = Visibility.Visible;
                _center.Visibility = Visibility.Visible;
            }
            else
            {
                _bottomMiddle.Visibility = Visibility.Hidden;
                _leftMiddle.Visibility   = Visibility.Hidden;
                _topMiddle.Visibility    = Visibility.Hidden;
                _rightMiddle.Visibility  = Visibility.Hidden;
                _topLeft.Visibility      = Visibility.Hidden;
                _topRight.Visibility     = Visibility.Hidden;
                _bottomLeft.Visibility   = Visibility.Hidden;
                _bottomRight.Visibility  = Visibility.Hidden;
                _center.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        ///     Update (redraw) thumbs positions
        /// </summary>
        public void UpdateThumbsPosition()
        {
            if ( _rectangleManager.RectangleHeight > 0 &&
                 _rectangleManager.RectangleWidth  > 0 )
            {
                _bottomMiddle.SetPosition(_rectangleManager.TopLeft.X +
                                           _rectangleManager.RectangleWidth / 2.0,
                                           _rectangleManager.TopLeft.Y +
                                           _rectangleManager.RectangleHeight);
                _leftMiddle.SetPosition(_rectangleManager.TopLeft.X,
                                         _rectangleManager.TopLeft.Y +
                                         _rectangleManager.RectangleHeight / 2.0);
                _topMiddle.SetPosition(_rectangleManager.TopLeft.X +
                                        _rectangleManager.RectangleWidth / 2.0,
                                        _rectangleManager.TopLeft.Y);
                _rightMiddle.SetPosition(_rectangleManager.TopLeft.X +
                                          _rectangleManager.RectangleWidth,
                                          _rectangleManager.TopLeft.Y +
                                          _rectangleManager.RectangleHeight / 2.0);
                _topLeft.SetPosition(_rectangleManager.TopLeft.X,
                                      _rectangleManager.TopLeft.Y);
                _topRight.SetPosition(_rectangleManager.TopLeft.X +
                                       _rectangleManager.RectangleWidth,
                                       _rectangleManager.TopLeft.Y);
                _bottomLeft.SetPosition(_rectangleManager.TopLeft.X,
                                         _rectangleManager.TopLeft.Y +
                                         _rectangleManager.RectangleHeight);
                _bottomRight.SetPosition(_rectangleManager.TopLeft.X +
                                          _rectangleManager.RectangleWidth,
                                          _rectangleManager.TopLeft.Y +
                                          _rectangleManager.RectangleHeight);
                _center.SetPosition(_rectangleManager.TopLeft.X +
                                         _rectangleManager.RectangleWidth / 2.0,
                                         _rectangleManager.TopLeft.Y +
                                         _rectangleManager.RectangleHeight / 2.0);
            }
        }

        private void BottomLeftDragDeltaEventHandler(object             sender,
                                                     DragDeltaEventArgs args)
        {
            double resultHeight = BottomSideCalculation(sender,
                                                        args);

            Tuple <double, double> leftSide = LeftSideCalculation(sender,
                                                                  args);

            UpdateRectangleSize(leftSide.Item1,
                                null,
                                resultHeight,
                                leftSide.Item2);
        }

        private void BottomMiddleDragDeltaEventHandler(
            object             sender,
            DragDeltaEventArgs args)
        {
            double resultHeight = BottomSideCalculation(sender,
                                                        args);

            UpdateRectangleSize(null,
                                null,
                                resultHeight,
                                null);
        }

        private void BottomRightDragDeltaEventHandler(object             sender,
                                                      DragDeltaEventArgs args)
        {
            double resultWidth = RightSideCalculation(sender,
                                                      args);

            double resultHeight = BottomSideCalculation(sender,
                                                        args);

            UpdateRectangleSize(null,
                                null,
                                resultHeight,
                                resultWidth);
        }

        private double BottomSideCalculation(object             sender,
                                             DragDeltaEventArgs args)
        {
            if ( !( sender is ThumbCrop thumb ) )
            {
                return 0.0;
            }

            double deltaVertical  = args.VerticalChange;
            double currentPoint   = Canvas.GetTop(thumb);
            double thumbResultTop = currentPoint + deltaVertical;

            if ( thumbResultTop + _thumbSize / 2.0 > _canvas.ActualHeight )
            {
                thumbResultTop = _canvas.ActualHeight - _thumbSize / 2.0;
            }

            double resultHeight = thumbResultTop -
                                  _rectangleManager.TopLeft.Y +
                                  _thumbSize / 2;

            return resultHeight;
        }

        private void LeftMiddleDragDeltaEventHandler(object             sender,
                                                     DragDeltaEventArgs args)
        {
            Tuple <double, double> leftSide = LeftSideCalculation(sender,
                                                                  args);

            UpdateRectangleSize(leftSide.Item1,
                                null,
                                null,
                                leftSide.Item2);
        }

        private Tuple <double, double> LeftSideCalculation(
            object             sender,
            DragDeltaEventArgs args)
        {
            if ( !( sender is ThumbCrop thumb ) )
            {
                return new Tuple <double, double>(0.0,
                                                  0.0);
            }

            double deltaHorizontal = args.HorizontalChange;
            double currentLeft     = Canvas.GetLeft(thumb);
            double resultThumbLeft = currentLeft + deltaHorizontal;

            if ( resultThumbLeft < 0 )
            {
                resultThumbLeft = -_thumbSize / 2.0;
            }

            double offset = currentLeft - resultThumbLeft;
            double resultLeft = resultThumbLeft + _thumbSize / 2.0;
            double resultWidth = _rectangleManager.RectangleWidth + offset;

            return Tuple.Create(resultLeft,
                                resultWidth);
        }

        private void PreviewMouseLeftButtonDownGenericHandler(object sender,
                                                              MouseButtonEventArgs args)
        {
            var thumb = sender as ThumbCrop;

            thumb?.CaptureMouse();
        }

        private void PreviewMouseLeftButtonUpGenericHandler(object sender,
                                                            MouseButtonEventArgs args)
        {
            var thumb = sender as ThumbCrop;

            thumb?.ReleaseMouseCapture();
        }

        private void RightMiddleDragDeltaEventHandler(object             sender,
                                                      DragDeltaEventArgs args)
        {
            double resultWidth = RightSideCalculation(sender,
                                                      args);

            UpdateRectangleSize(null,
                                null,
                                null,
                                resultWidth);
        }

        private double RightSideCalculation(object             sender,
                                            DragDeltaEventArgs args)
        {
            if ( !( sender is ThumbCrop thumb ) )
            {
                return 0.0;
            }

            double deltaHorizontal = args.HorizontalChange;
            double currentLeft     = Canvas.GetLeft(thumb);
            double resultThumbLeft = currentLeft + deltaHorizontal;

            if ( resultThumbLeft > _canvas.ActualWidth )
            {
                resultThumbLeft = _canvas.ActualWidth;
            }

            return resultThumbLeft - _rectangleManager.TopLeft.X;
        }

        private void TopLeftDragDeltaEventHandler(object             sender,
                                                  DragDeltaEventArgs args)
        {
            Tuple <double, double> topSide = TopSideCalculation(sender,
                                                                args);
            Tuple<double, double> leftSide = LeftSideCalculation(sender,
                                                                 args);

            UpdateRectangleSize(leftSide.Item1,
                                topSide.Item1,
                                topSide.Item2,
                                leftSide.Item2);
        }

        private void TopMiddleDragDeltaEventHandler(object             sender,
                                                    DragDeltaEventArgs args)
        {
            Tuple <double, double> topSide = TopSideCalculation(sender,
                                                                args);

            UpdateRectangleSize(null,
                                topSide.Item1,
                                topSide.Item2,
                                null);
        }

        private void TopRightDragDeltaEventHandler(object             sender,
                                                   DragDeltaEventArgs args)
        {
            Tuple <double, double> topSide = TopSideCalculation(sender,
                                                                args);

            double resultWidth = RightSideCalculation(sender,
                                                      args);
            UpdateRectangleSize(null,
                                topSide.Item1,
                                topSide.Item2,
                                resultWidth);
        }

        private Tuple <double, double> TopSideCalculation(
            object             sender,
            DragDeltaEventArgs args)
        {
            if ( !( sender is ThumbCrop thumb ) )
            {
                return new Tuple <double, double>(0.0,
                                                  0.0);
            }

            double deltaVertical  = args.VerticalChange;
            double currentPoint   = Canvas.GetTop(thumb);
            double resultThumbTop = currentPoint + deltaVertical;

            if ( resultThumbTop < 0.0 )
            {
                resultThumbTop = -_thumbSize / 2.0;
            }

            double offset = currentPoint - resultThumbTop;
            double resultHeight = _rectangleManager.RectangleHeight + offset;
            double resultTop = resultThumbTop + _thumbSize / 2.0;

            return Tuple.Create(resultTop,
                                resultHeight);
        }

        private void CenterDragDeltaEventHandler(
            object             sender,
            DragDeltaEventArgs args)
        {
            Tuple <double, double> topLeftCorner = CenterCalculation(sender,
                                                               args);

            UpdateRectangleSize(topLeftCorner.Item1,
                                topLeftCorner.Item2,
                                null,
                                null);
        }

        private Tuple<double, double> CenterCalculation(
            object sender,
                                                        DragDeltaEventArgs
                                                            args)
        {
            Tuple<double, double> topSide = TopSideCalculation(sender,
                                                               args);
            Tuple<double, double> leftSide = LeftSideCalculation(sender,
                                                                 args);

            double topLeftCornerX = leftSide.Item1  - _rectangleManager.RectangleWidth  / 2.0;
            double topLeftCornerY = topSide.Item1 - _rectangleManager.RectangleHeight / 2.0;

            topLeftCornerX = ValidateTopLeftCornerX(topLeftCornerX);
            topLeftCornerY = ValidateTopLeftCornerY(topLeftCornerY);

            return new Tuple<double, double>(topLeftCornerX,
                                             topLeftCornerY);
        }

        private double ValidateTopLeftCornerY(double topLeftCornerY)
        {
            if ( topLeftCornerY < 0 )
                topLeftCornerY = 0.0;
            if ( topLeftCornerY + _rectangleManager.RectangleHeight >
                 _canvas.ActualHeight )
                topLeftCornerY =
                    _canvas.ActualHeight - _rectangleManager.RectangleHeight;
            return topLeftCornerY;
        }

        private double ValidateTopLeftCornerX(double topLeftCornerX)
        {
            if ( topLeftCornerX < 0 )
                topLeftCornerX = 0.0;
            if ( topLeftCornerX + _rectangleManager.RectangleWidth >
                 _canvas.ActualWidth )
                topLeftCornerX = _canvas.ActualWidth - _rectangleManager.RectangleWidth;
            return topLeftCornerX;
        }

        /// <summary>
        ///     Update cropping rectangle
        /// </summary>
        /// <param name="left">Left rectangle coordinate</param>
        /// <param name="top">Top rectangle coordinate</param>
        /// <param name="height">Height of rectangle</param>
        /// <param name="width">Width of rectangle</param>
        private void UpdateRectangleSize(double? left,
                                         double? top,
                                         double? height,
                                         double? width)
        {
            double resultLeft   = _rectangleManager.TopLeft.X;
            double resultTop    = _rectangleManager.TopLeft.Y;
            double resultHeight = _rectangleManager.RectangleHeight;
            double resultWidth  = _rectangleManager.RectangleWidth;

            if ( left != null )
            {
                resultLeft = ( double ) left;
            }

            if ( top != null )
            {
                resultTop = ( double ) top;
            }

            if ( height != null )
            {
                resultHeight = ( double ) height;
            }

            if ( width != null )
            {
                resultWidth = ( double ) width;
            }

            _rectangleManager.UpdateRectangle(resultLeft,
                                               resultTop,
                                               resultWidth,
                                               resultHeight);

            UpdateThumbsPosition();
        }
    }
}
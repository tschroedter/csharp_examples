using System;
using System.Windows;
using System.Windows.Threading;

namespace UserControls
{
    /// <summary>
    ///     Interaction logic for UniversalClock.xaml
    /// </summary>
    public partial class UniversalClock : IDisposable
    {
        public UniversalClock()
        {
            InitializeComponent();

            m_DispatcherTimer.Tick += OnTick;
            m_DispatcherTimer.Interval = 2.Seconds();
            m_DispatcherTimer.Start();
        }

        public static readonly DependencyProperty UtcDateTimeProperty =
            DependencyProperty.Register("UtcDateTime",
                                        typeof( DateTime ),
                                        typeof( UniversalClock ),
                                        new PropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty TimeZoneProperty =
            DependencyProperty.Register("TimeZone",
                                        typeof( TimeZoneInfo ),
                                        typeof( UniversalClock ),
                                        new PropertyMetadata(TimeZoneInfo.Utc));

        public static readonly DependencyProperty IsVisibleTimeZoneProperty =
            DependencyProperty.Register("IsVisibleTimeZone",
                                        typeof( bool ),
                                        typeof( UniversalClock ),
                                        new PropertyMetadata(false));

        public static readonly DependencyProperty IsVisibleDateProperty =
            DependencyProperty.Register("IsVisibleDate",
                                        typeof(bool),
                                        typeof(UniversalClock),
                                        new PropertyMetadata(false));

        public static readonly DependencyProperty IsVisibleTimeProperty =
            DependencyProperty.Register("IsVisibleTime",
                                        typeof(bool),
                                        typeof(UniversalClock),
                                        new PropertyMetadata(false));


        public static readonly DependencyProperty LocalDateTimeProperty =
            DependencyProperty.Register("LocalDateTime",
                                        typeof(DateTime),
                                        typeof(UniversalClock),
                                        new PropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty DateFormatProperty =
            DependencyProperty.Register("DateFormat",
                                        typeof(string),
                                        typeof(UniversalClock),
                                        new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TimeFormatProperty =
            DependencyProperty.Register("TimeFormat",
                                        typeof(string),
                                        typeof(UniversalClock),
                                        new PropertyMetadata(string.Empty));

        public DateTime UtcDateTime
        {
            get => ( DateTime ) GetValue(UtcDateTimeProperty);
            set
            {
                SetValue(UtcDateTimeProperty,
                         value);
                SetValue(LocalDateTimeProperty,
                         TimeZoneInfo.ConvertTimeFromUtc(value, TimeZone));
            }
        }

        public DateTime LocalDateTime => (DateTime)GetValue(UtcDateTimeProperty);

        public string DateFormat
        {
            get => (string)GetValue(DateFormatProperty);
            set => SetValue(DateFormatProperty,
                            value);
        }

        public string TimeFormat
        {
            get => (string)GetValue(TimeFormatProperty);
            set => SetValue(TimeFormatProperty,
                            value);
        }

        public TimeZoneInfo TimeZone
        {
            get => ( TimeZoneInfo ) GetValue(TimeZoneProperty);
            set => SetValue(TimeZoneProperty,
                            value);
        }

        public bool IsVisibleDate
        {
            get => (bool)GetValue(IsVisibleDateProperty);
            set => SetValue(IsVisibleDateProperty,
                            value);
        }

        public bool IsVisibleTime
        {
            get => (bool)GetValue(IsVisibleTimeProperty);
            set => SetValue(IsVisibleTimeProperty,
                            value);
        }

        public bool IsVisibleTimeZone
        {
            get => ( bool ) GetValue(IsVisibleTimeZoneProperty);
            set => SetValue(IsVisibleTimeZoneProperty,
                            value);
        }

        private readonly DispatcherTimer m_DispatcherTimer = new DispatcherTimer();

        public void Dispose()
        {
            m_DispatcherTimer.Stop();
            m_DispatcherTimer.Tick -= OnTick;
        }

        private void OnTick(object    sender,
                            EventArgs e)
        {
            UtcDateTime = DateTime.UtcNow;
        }
    }
}
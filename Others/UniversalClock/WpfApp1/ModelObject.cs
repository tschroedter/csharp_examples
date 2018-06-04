using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Properties;

namespace WpfApp1
{
    public class ModelObject : INotifyPropertyChanged
    {
        public string DateFormat
        {
            get => m_FormatDate;
            set
            {
                m_FormatDate = value;

                OnPropertyChanged(nameof(DateFormat));
            }
        }

        public string TimeFormat
        {
            get => m_FormatTime;
            set
            {
                m_FormatTime = value;

                OnPropertyChanged(nameof(TimeFormat));
            }
        }

        public TimeZoneInfo TimeZoneCst
        {
            get => m_TimeZoneCst;
            set
            {
                m_TimeZoneCst = value;

                OnPropertyChanged(nameof(TimeZoneCst));
            }
        }

        public TimeZoneInfo TimeZoneEst
        {
            get => m_TimeZoneEst;
            set
            {
                m_TimeZoneEst = value;

                OnPropertyChanged(nameof(TimeZoneEst));
            }
        }

        public TimeZoneInfo TimeZoneWst
        {
            get => m_TimeZoneWst;
            set
            {
                m_TimeZoneWst = value;

                OnPropertyChanged(nameof(TimeZoneWst));
            }
        }

        public TimeZoneInfo TimeZoneUtc
        {
            get => m_TimeZoneUtc;
            set
            {
                m_TimeZoneUtc = value;

                OnPropertyChanged(nameof(TimeZoneUtc));
            }
        }

        public bool IsVisibleTimeZone
        {
            get => m_IsVisibleTimeZone;
            set
            {
                m_IsVisibleTimeZone = value;

                OnPropertyChanged(nameof(IsVisibleTimeZone));
            }
        }

        public bool IsVisibleDate
        {
            get => m_IsVisibleDate;
            set
            {
                m_IsVisibleDate = value;

                OnPropertyChanged(nameof(IsVisibleDate));
            }
        }

        public bool IsVisibleTime
        {
            get => m_IsVisibleTime;
            set
            {
                m_IsVisibleTime = value;

                OnPropertyChanged(nameof(IsVisibleTime));
            }
        }

        private string m_FormatDate = "dd-MM-yyyy";
        private string m_FormatTime = "HH:mm:ss";
        private bool   m_IsVisibleDate     = true;
        private bool   m_IsVisibleTime     = true;
        private bool   m_IsVisibleTimeZone = true;

        private TimeZoneInfo m_TimeZoneCst =
            TimeZoneInfo.FindSystemTimeZoneById("Cen. Australia Standard Time");

        private TimeZoneInfo m_TimeZoneEst =
            TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");

        private TimeZoneInfo m_TimeZoneWst =
            TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");


        private TimeZoneInfo m_TimeZoneUtc = TimeZoneInfo.Utc;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                                    new PropertyChangedEventArgs(propertyName));
        }
    }
}
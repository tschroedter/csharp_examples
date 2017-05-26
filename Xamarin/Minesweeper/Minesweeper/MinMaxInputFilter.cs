using System;
using Android.Text;
using Java.Lang;
using Exception = Java.Lang.Exception;
using Object = Java.Lang.Object;
using String = Java.Lang.String;

namespace Minesweeper
{
    public class MinMaxInputFilter
        : Object,
          IInputFilter
    {
        public MinMaxInputFilter(int min,
                                 int max)
        {
            m_Min = min;
            m_Max = max;
        }

        private readonly int m_Max;
        private readonly int m_Min;

        public ICharSequence FilterFormatted(ICharSequence source,
                                             int start,
                                             int end,
                                             ISpanned dest,
                                             int dstart,
                                             int dend)
        {
            try
            {
                string val = dest.ToString().Insert(dstart,
                                                    source.ToString());
                int input = int.Parse(val);
                if ( IsInRange(m_Min,
                               m_Max,
                               input) )
                {
                    return null;
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine("FilterFormatted Error: " + ex.Message);
            }

            return new String(string.Empty);
        }

        private bool IsInRange(int min,
                               int max,
                               int input)
        {
            return max > min
                       ? ( input >= min ) && ( input <= max )
                       : ( input >= max ) && ( input <= min );
        }
    }
}
using System;

namespace KuantDotNet.KuantDateTime
{
    public class TimeUtil
    {
        public static double AccurateYearSpan(KDateTime start, KDateTime end)
        {
            return (end - start).Days / 365.25;
        }
        public static int YearSpan(KDateTime start, KDateTime end)
        {
            return end.Year - start.Year;
        }
        public static int MonthSpan(KDateTime start, KDateTime end)
        {
            return ((end.Year - start.Year) * 12) + end.Month - start.Month;
        }

        public static int DaySpan(KDateTime start, KDateTime end)
        {
            return (end - start).Days;
        }

        public static long TickSpan(KDateTime start, KDateTime end)
        {
            return start.Ticks - end.Ticks;
        }
    }
}

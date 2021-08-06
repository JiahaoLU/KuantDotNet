using System;

namespace Kuant.Utils
{
    public static class TimeUtil
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
        /*
        /// <summary>
        /// Calculate how many working days there are between two given days.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int WorkingDaySpan(KDateTime start, KDateTime end)
        {
            var daySpan = DaySpan(start, end);
            int weeks = daySpan / 7;
            int residual = daySpan % 7;
            if  (daySpan >= 7)
            {
                return daySpan - (daySpan / 7) * 2;
            }
        }*/
        public static long TickSpan(KDateTime start, KDateTime end)
        {
            return start.Ticks - end.Ticks;
        }
    }
}

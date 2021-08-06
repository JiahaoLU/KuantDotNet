using System;

namespace Kuant.Utils
{
    public static class TimeUtil
    {
        public static double AccurateYearSpan(KDateTime start, KDateTime end, DayCount dayCount = DayCount.A360)
        {
            switch (dayCount)
            {
                case DayCount.A360:
                    return (end - start).Days / 360;
                case DayCount.A365F:
                    return (end - start).Days / 365;
                case DayCount.Thirty360:
                    var d1 = start.DT.Day == 31 ? 30 : start.DT.Day;
                    var d2 = (d1 == 30 && end.DT.Day == 31) ? 30 : end.DT.Day;
                    var num = (d2 - d1) + 30 * MonthSpan(start, end);
                    return num / 360;
                default:
                    throw new ArgumentException("Day Count Type not found.");
            }
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

         /// <summary>
        /// Calculates number of business days, taking into account:
        ///  - weekends (Saturdays and Sundays)
        ///  - bank holidays in the middle of the week
        /// </summary>
        /// <param name="firstDate">First day in the time interval</param>
        /// <param name="lastDate">Last day in the time interval</param>
        /// <param name="bankHolidays">List of bank holidays excluding weekends</param>
        /// <returns>Number of business days during the 'span'</returns>
        public static int WorkingDaySpan(KDateTime firstDay, KDateTime lastDay, params KDateTime[] bankHolidays)
        {
            var firstDate = firstDay.DT.Date;
            var lastDate = lastDay.DT.Date;
            if (firstDate > lastDate)
                throw new ArgumentException("Incorrect last day " + lastDate);

            TimeSpan span = lastDate - firstDate;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount*7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = firstDate.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)firstDate.DayOfWeek;
                int lastDayOfWeek = lastDate.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lastDate.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }

            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;

            // subtract the number of bank holidays during the time interval
            foreach (KDateTime bankHoliday in bankHolidays)
            {
                DateTime bh = bankHoliday.DT.Date;
                if (firstDate <= bh && bh <= lastDate && bankHoliday.IsWorkingDay())
                    --businessDays;
            }

            return businessDays;
        }

        public static long TickSpan(KDateTime start, KDateTime end)
        {
            return start.Ticks - end.Ticks;
        }
    }
}

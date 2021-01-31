using System;

namespace KuantDotNet.KuantDateTime
{
    public class TimeUtil
    {
        public static int MonthSpan(DateTime date1, DateTime date2)
        {
            return date2.Month - date1.Month;
        }
    }
}

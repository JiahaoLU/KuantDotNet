using System;

namespace Kuant.Utils
{
    public class KDateTime : IComparable, ICloneable, IComparable<KDateTime>
    {
        public DateTime DT { get; }
        public int Month {get{return DT.Month;}}
        public long Ticks { get { return DT.Ticks; }}

        public int Year { get { return DT.Year;} }

        public KDateTime(DateTime dt)
        {
            // offseet weekend to last Friday
            DT = dt;
        }
        public KDateTime(int y, int m, int d)
        {
            DT = new DateTime(y, m, d);
        }
        public KDateTime AddYears(int year)
        {
            return new KDateTime(DT.AddYears(year));
        }

        public KDateTime AddMonths(int m)
        {
            return new KDateTime(DT.AddMonths(m));
        }
        public KDateTime AddWorkingDays(int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            DateTime dt = DT;
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    dt = dt.AddDays(sign);
                } while (dt.DayOfWeek == DayOfWeek.Saturday ||
                         dt.DayOfWeek == DayOfWeek.Sunday);
            }
            return new KDateTime(dt);
        }

        public KDateTime AddDays(int days)
        {
            return new KDateTime(DT.AddDays(days));
        }

        public KDateTime AddExpiry(Frequency freq)
        {
            switch (freq)
            {
                case Frequency.Annual:
                    return AddYears(1);
                case Frequency.Semiannual:
                    return AddMonths(6);
                case Frequency.Quarterly:
                    return AddMonths(3);
                case Frequency.Monthly:
                    return AddMonths(1);
                case Frequency.Weekly:
                    return AddDays(7); // to be validated
                case Frequency.Daily:
                    return AddWorkingDays(1); // to be validated
                default:
                    return null;
            }
            
        }
        public bool IsWorkingDay(){
            return !(DT.DayOfWeek == DayOfWeek.Sunday || DT.DayOfWeek == DayOfWeek.Saturday);
        }
        public static TimeSpan operator -(KDateTime d1, KDateTime d2)
        {
            // to do : offset weekends
            return d1.DT - d2.DT;
        }
        public static bool operator <=(KDateTime d1, KDateTime d2)
        {
            var compare = d1.CompareTo(d2);
            return compare <= 0;
        }
        public static bool operator >=(KDateTime d1, KDateTime d2)
        {
            var compare = d1.CompareTo(d2);
            return compare >= 0;
        }

        public static bool operator ==(KDateTime d1, KDateTime d2)
        {
            if (d1 is null)
            {
                return d2 is null;
            }
            return d1.Equals(d2);
        }
        public static bool operator !=(KDateTime d1, KDateTime d2)
        {
            return !(d1 == d2);
        }
        public static bool operator >(KDateTime d1, KDateTime d2)
        {
            return d1.CompareTo(d2) > 0;
        }
        public static bool operator <(KDateTime d1, KDateTime d2)
        {
            return d1.CompareTo(d2) < 0;
        }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            if (obj is KDateTime) {
                return DT == ((KDateTime)obj).DT;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return DT.GetHashCode();
        }

        public override string ToString()
        {
            return DT.ToString();
        }

        public int CompareTo(object obj)
        {
            return CompareTo((KDateTime)obj);
        }

        public int CompareTo(KDateTime obj)
        {
            int res = 1;
            if (obj != null)
            {
                res = obj.DT == DT ? 0 : DT < obj.DT ? -1 : 1;
            }
            return res;
        }
        public object Clone()
        {
            return new KDateTime(DT);
        }
    }
}
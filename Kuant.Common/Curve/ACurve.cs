using System;
using System.Collections.Generic;
using System.Linq;
using KMath = Kuant.Math;
using Kuant.Utils;

namespace Kuant.Common
{
    public abstract class ACurve : ICompounding
    {
        public string Index { get; set; }
        
        public ISeriesValue<KDateTime, double> Rate { get; set; }

        /// <summary>
        /// Compounding frequency
        /// </summary>
        /// <value></value>
        public Frequency CompFreq { get; set; }

        public DayCount DayCount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="r"></param>
        /// <param name="cfreq">compounding frequency</param>
        public ACurve(string index, ISeriesValue<KDateTime, double> r, 
            Frequency cfreq, DayCount dayCount)
        {
            Index = index;
            Rate = r;
            CompFreq = cfreq;
            DayCount = dayCount;
        }

        /// <summary>
        /// Regard Rate as zero coupon rate, given a zero date and return discount factor.<br/>
        /// zero => discount factor
        /// </summary>
        /// <param name="asof"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public double DiscountValue(KDateTime asof, KDateTime date)
        {
            CheckDate(asof, date);
            if (CompFreq == Frequency.Continuous)
            {
                return System.Math.Exp(-Rate.GetValue(date) 
                                    * TimeUtil.AccurateYearSpan(asof, date, DayCount));
            }
            
            return System.Math.Pow(
                1 + Rate.GetValue(date) / (int)CompFreq, 
                -(int)CompFreq * TimeUtil.AccurateYearSpan(asof, date, DayCount));
        }

        /// <summary>
        /// Regard Rate as discount rate, given a present date and return zero rate.<br/>
        /// discount factor => zero
        /// </summary>
        /// <param name="asof"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public double ReturnValue(KDateTime asof, KDateTime date)
        {
            CheckDate(asof, date);
            if (CompFreq == Frequency.Continuous)
            {
                return - System.Math.Log(Rate.GetValue(date))
                                    / TimeUtil.AccurateYearSpan(asof, date, DayCount);
            }

            return (int)CompFreq * (System.Math.Pow(
                                        Rate.GetValue(date), 
                                        -1 / (int)CompFreq / TimeUtil.AccurateYearSpan(asof, date, DayCount)) 
                                    - 1);
        }

        protected void CheckDate(KDateTime asof, KDateTime date)
        {
            if (date < asof)
                throw new Exception("target date is anterior to asof date.");
        }
    }
}
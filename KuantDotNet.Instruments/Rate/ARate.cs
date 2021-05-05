using System;
using System.Collections.Generic;
using System.Linq;
using KuantDotNet.Instruments.SeriesValue;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.Rate
{
    public abstract class ARate : ICompounding
    {

        public string RName { get; set; }
        
        public ISeriesValue<KDateTime, double> Rate { get; set; }

        /// <summary>
        /// Compounding frequency
        /// </summary>
        /// <value></value>
        public Frequency CompFreq { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rname"></param>
        /// <param name="r"></param>
        /// <param name="cfreq">compounding frequency</param>
        public ARate(string rname, ISeriesValue<KDateTime, double> r, Frequency cfreq)
        {
            RName = rname;
            Rate = r;
            CompFreq = cfreq;
        }

        /// <summary>
        /// Present value of zero coupon received at given date.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="asof"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public double DiscountValue(double amount,  KDateTime asof, KDateTime date)
        {
            CheckDate(asof, date);
            if (CompFreq == Frequency.Continuous)
                return amount * Math.Exp(-Rate.GetValue(date) 
                                    * TimeUtil.AccurateYearSpan(asof, date));
            
            return amount * Math.Pow(
                1 + Rate.GetValue(date) / (int)CompFreq, 
                -(int)CompFreq * TimeUtil.AccurateYearSpan(asof, date));
        }

        public double ReturnValue(double amount,  KDateTime asof, KDateTime date)
        {
            CheckDate(asof, date);
            if (CompFreq == Frequency.Continuous)
                return amount * Math.Exp(Rate.GetValue(date) 
                                    * TimeUtil.AccurateYearSpan(asof, date));

            return amount * Math.Pow(
                1 + Rate.GetValue(date) / (int)CompFreq, 
                (int)CompFreq * TimeUtil.AccurateYearSpan(asof, date));
        }

        protected void CheckDate(KDateTime asof, KDateTime date)
        {
            if (date < asof)
                throw new Exception("target date is anterior to asof date.");
        }
    }
}
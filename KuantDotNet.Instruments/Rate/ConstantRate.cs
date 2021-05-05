using System;
using System.Collections.Generic;
using System.Linq;
using KuantDotNet.Instruments.SeriesValue;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.Rate
{
    /// <summary>
    /// Constant rate per annum
    /// </summary>
    public class ConstantRate : ARate
    {
        public ConstantRate(string rname, ConstantValue<double> r, Frequency cfreq)
         : base(rname, r, cfreq)
        {
        }

    }
}
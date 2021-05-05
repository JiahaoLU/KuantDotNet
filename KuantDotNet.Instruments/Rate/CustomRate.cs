using System;
using System.Collections.Generic;
using System.Linq;
using KuantDotNet.Instruments.SeriesValue;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.Rate
{
    /// <summary>
    /// custom rate
    /// </summary>
    public class CustomRate : ARate
    {
       public CustomRate(string rname, SeriesValue<double> r, Frequency cfreq)
         : base(rname, r, cfreq)
        {
        }

    }
}
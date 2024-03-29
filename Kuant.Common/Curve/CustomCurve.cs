using System;
using System.Collections.Generic;
using System.Linq;
using Kuant.Utils;

namespace Kuant.Common
{
    /// <summary>
    /// custom curve
    /// </summary>
    public class CustomCurve : ACurve
    {
       public CustomCurve(string index, SeriesValue<double> r, Frequency cfreq, DayCount dayCount)
         : base(index, r, cfreq, dayCount)
        {
        }

    }
}
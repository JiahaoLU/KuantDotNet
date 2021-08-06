using System;
using System.Collections.Generic;
using System.Linq;
using Kuant.Utils;

namespace Kuant.Common
{
    /// <summary>
    /// Constant curve per annum
    /// </summary>
    public class ConstantCurve : ACurve
    {
        public ConstantCurve(string rname, ConstantValue<double> r, Frequency cfreq, DayCount dayCount)
         : base(rname, r, cfreq, dayCount)
        {
        }

    }
}
using System.Collections.Generic;
using KuantDotNet.Instruments.Rate;
using KuantDotNet.Instruments.SeriesValue;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments
{
    public class VarRateBond : ABond
    {
        public VarRateBond(double nominal, int maturity, Frequency payf,
         SeriesValue<double> coupon, CustomRate yrate, KDateTime start) 
         : base(nominal, maturity, payf, coupon, yrate, start)
        {
        }

        public override double BondYield(KDateTime asof)
        {
            throw new System.NotImplementedException();
        }

        public override double ParYield(KDateTime asof)
        {
            throw new System.NotImplementedException();
        }

        public override double SpotPriceAsUnderlying(KDateTime asof)
        {
            throw new System.NotImplementedException();
        }
    }
}
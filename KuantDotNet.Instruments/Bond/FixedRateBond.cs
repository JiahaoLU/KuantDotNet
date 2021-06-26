using System.Collections.Generic;
using KuantDotNet.Instruments.Rate;
using KuantDotNet.Instruments.SeriesValue;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments
{
    public class FixedRateBond : ABond
    {
        public FixedRateBond(double nominal, int maturity, Frequency payf,
         ConstantValue<double> coupon, ARate yrate, KDateTime start) 
         : base(nominal, maturity, payf, coupon, yrate, start)
        {
        }
        public override double SpotPriceAsUnderlying(KDateTime asof)
        {
            double price = 0;
            if (asof > StartDate)
            {
                Logger.Warn("Current date later than start date.");
            }
            var cp = ((ConstantValue<double>)Coupon).Constant * Nominal;
            var expiry = (KDateTime)StartDate.Clone();
            for (var i = 0; i < Maturity * (int)PayFreq; i++)
            {
                expiry = expiry.AddExpiry(PayFreq);
                
                if (expiry < asof)
                    continue;
            
                price += YieldRate.DiscountValue(cp, asof, expiry);
            }
            if (asof <= expiry)
                price += YieldRate.DiscountValue(Nominal, asof, expiry);
            
            return price;
        }

        public override double ParYield(KDateTime asof)
        {
            if (asof > StartDate)
            {
                var ex = new System.Exception(
                    "Asof date must be earlier or same as start date to get par yield.");
                Logger.Error(ex.Message, ex);
                throw ex;
            }
            double A = 0;

            var expiry = (KDateTime)StartDate.Clone();
            for (var i = 0; i < Maturity * (int)PayFreq; i++)
            {
                expiry = expiry.AddExpiry(PayFreq);
                A += YieldRate.DiscountValue(1, asof, expiry);
            }
            double d = YieldRate.DiscountValue(1, asof, expiry);
            return Nominal * (1 - d) * (int)PayFreq / A / 100;
        }

        public override double BondYield(KDateTime asof)
        {
            throw new System.NotImplementedException();
        }
    }
}
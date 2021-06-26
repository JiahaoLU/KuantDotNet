using System.Collections.Generic;
using KuantDotNet.Instruments.Rate;
using KuantDotNet.Instruments.SeriesValue;
using KuantDotNet.KuantDateTime;
using log4net;

namespace KuantDotNet.Instruments
{
    public abstract class ABond : IUnderlying
    {
        #region Logger
        public ILog Logger { get;}
        
        #endregion
        public Ccy Ccy { get; set; } = Ccy.EUR;
        public double Nominal { get; set; }
        /// <summary>
        /// year
        /// </summary>
        public int Maturity { get; }
        public Frequency PayFreq { get; set; }
        
        /// <summary>
        /// Percentage
        /// </summary>
        /// <value></value>
        public ISeriesValue<KDateTime, double> Coupon { get; set; }

        public bool IsFinancialAsset { get { return true; } }

        public ARate YieldRate { get; set; }

        // to do : verify definition of start date
        /// <summary>
        /// Count down expiries starting from this date
        /// </summary>
        /// <value></value>
        public KDateTime StartDate { get; set; }
        
        public KDateTime EndDate { get { return StartDate.AddYears(Maturity); } }
        
        public ABond(double nominal, int maturity, Frequency payf,
         ISeriesValue<KDateTime, double> coupon, ARate yrate, KDateTime start)
        {
            Logger = LogManager.GetLogger(GetType());
            Nominal = nominal;
            Maturity = maturity;
            Coupon = coupon;
            if (payf == Frequency.Continuous)
            {
                Logger.Warn("Continuous payment not available for bond. Set to default annual.");
                PayFreq = Frequency.Annual;
            }
            else{
                PayFreq = payf;
            }
            YieldRate = yrate;
            StartDate = start;
        }

        public abstract double SpotPriceAsUnderlying(KDateTime asof);
        public abstract double ParYield(KDateTime asof);
        public abstract double BondYield(KDateTime asof);

    }
}
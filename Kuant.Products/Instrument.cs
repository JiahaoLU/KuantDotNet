using Kuant.Common;
using Kuant.Utils;
using Kuant.Config;

namespace Kuant.Products
{
    public abstract class Instrument : IProduct
    {
        #region Inherit IProduct
        public virtual KDateTime StartDate { get ; set ; }
        public virtual KDateTime EndDate { get ; set; }
        public double? PV { get ; set; }
        public virtual bool IsPriceable()
        {
            return StartDate < EndDate;
        }
        #endregion

        public virtual INotional Notional { get; set ; }
        public virtual Ccy Ccy { get; set; }
        public PayRecieve PoR { get; set; }
        
        public virtual object Clone()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return string.Join(DefaultConfig.DefaultDataKeyDelimiter,
                                StartDate,
                                EndDate,
                                Ccy,
                                PoR,
                                Notional);
        }
    }
}
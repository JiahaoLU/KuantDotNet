using Kuant.Common;
using Kuant.Utils;

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

        public virtual INotional Notional { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public virtual Ccy Ccy { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public PayOrRecieve PoR { get; set; }
        
        public virtual object Clone()
        {
            throw new System.NotImplementedException();
        }

    }
}
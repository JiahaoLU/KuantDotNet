using System;
using System.Collections.Generic;
using System.Linq;

namespace KuantDotNet.Instruments
{
    /// <summary>
    /// Futures contract model
    /// </summary>
    public class Futures
    {
    #region Properties
        /// <summary>
        /// Underlying asset
        /// </summary>
        /// <value></value>
        public IUnderlying Asset { get; }
        /// <summary>
        /// Asset Size
        /// </summary>
        /// <value></value>
        public double Size { get; }
        public int DeliveryArrange { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ContractDate { get; set; }
        
        
        /// <summary>
        /// Converges to spot price when t -> delivery date
        /// </summary>
        /// <value></value>
        public List<double> UnitPrice { get; set; }

        public double DeliveryUnitPrice { get; }
        public double PriceLimit { get; set; }
        
        public int PositionLimit { get; set; }
        
        
        public LongShort Position { get; }

        public double MarginAccount { get; set; }
        public double MaintenanceMargin { get; set; }
        public double InitialMargin { get; }
        
        public double Payoff 
        {
            get{
                if (Position == LongShort.Long)
                    return Size * (Asset.GetSpotPriceAsUnderlying() - DeliveryUnitPrice); 
                else
                    return - Size * (Asset.GetSpotPriceAsUnderlying() - DeliveryUnitPrice);
            }
        }
        /// <summary>
        /// basis for unit price
        /// </summary>
        /// <value></value>
        public double Basis 
        {
            get{
                if (Asset.IsFinancialAsset)
                    return UnitPrice.Last() - Asset.GetSpotPriceAsUnderlying();
                else
                    return Asset.GetSpotPriceAsUnderlying() - UnitPrice.Last();
            }
        }
        
        
    #endregion
    #region Ctor
        public Futures(IUnderlying underlying, double size, double deliveryUnitPrice,
             LongShort position, DateTime deliveryDate, DateTime contractDate,
             double price0, double initMargin, double maintenance)
        {
            Asset = underlying;
            Size = size;
            DeliveryUnitPrice = deliveryUnitPrice;
            Position = position;
            DeliveryDate = deliveryDate;
            ContractDate = contractDate;
            InitialMargin = initMargin;
            MarginAccount = initMargin;
            UnitPrice = new List<double>{ price0 };
            MaintenanceMargin = maintenance;
        }
    #endregion
    #region method
        public void DailySettlement(double spotFuturePrice)
        {
            if (Position == LongShort.Long)
            {
                MarginAccount += Size * (spotFuturePrice - UnitPrice.Last());
            }
            else
            {
                MarginAccount -= Size * (spotFuturePrice - UnitPrice.Last());
            }
            UnitPrice.Add(spotFuturePrice);
            if (MarginAccount < MaintenanceMargin)
            {
                MarginCall(true);
            } 
        }

        private void MarginCall(bool neverDefault)
        {
            //execute call immediately, supposed to be done next day
            if (neverDefault)
                MarginAccount = InitialMargin;
            System.Console.WriteLine("Do margin call");
        }

    #endregion

    }
}
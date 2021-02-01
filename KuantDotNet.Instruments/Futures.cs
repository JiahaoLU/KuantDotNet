using System;
using System.Collections.Generic;
using System.Linq;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments
{
    /// <summary>
    /// <para>Futures contract model</para>
    /// to do: Datetime scale default to be daily -> monthly, yearly, ...
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
        /// Futures price: Converges to spot price when t -> delivery date
        /// </summary>
        /// <value></value>
        public List<double> UnitPrice { get; set; }
        public int LastDateIdx { get { return UnitPrice.Count - 1; } }
        
        
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
                var span = TimeUtil.DaySpan(ContractDate, DeliveryDate);
                var payoff = Size * (Asset.SpotPriceAsUnderlying(LastDateIdx) - DeliveryUnitPrice);
                if (Position == LongShort.Short)
                    payoff *= -1; 
                if (span > LastDateIdx + 1)
                    System.Console.WriteLine("Delivery date has not arrived yet. Payoff calculated using current underlying price");
                else if (span <= LastDateIdx)
                    System.Console.WriteLine("Attention: Delivery has been done");
                return payoff;
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

        public Futures()
        {
        }
        #endregion
        #region method
        /// <summary>
        /// basis for unit price
        /// </summary>
        /// <value></value>
        public double Basis(int idx) 
        {
            var basis = UnitPrice[idx] - Asset.SpotPriceAsUnderlying(idx);
            if (!Asset.IsFinancialAsset)
                basis *= -1;
            return basis;
        }
        public void DailySettlement(double spotFuturesPrice)
        {
            var pnl = Size * (spotFuturesPrice - UnitPrice.Last());
            if (Position == LongShort.Short)
                pnl *= -1;
            MarginAccount += pnl;

            UnitPrice.Add(spotFuturesPrice);
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
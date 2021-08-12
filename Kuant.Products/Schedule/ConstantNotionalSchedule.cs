using System.Collections.Generic;
using System.Data;
using Kuant.Utils;
using Kuant.Config;

namespace Kuant.Products
{
    public class ConstantNotionalSchedule : IConstantSchedule, INotional
    {
        private double _notional = DefaultConfig.DefaultNotional;
        public double Notional 
        { 
            get => _notional; 
            set {_notional = value;}
        }
        
        
        public object[] ConstantValues { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public KDateTime StartDate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public KDateTime EndDate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ConstantNotionalSchedule()
        {
            
        }
        public object Clone()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetCompleteSchedule()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> GetRow(KDateTime date)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"NScd {Notional}";
        }
    }
}
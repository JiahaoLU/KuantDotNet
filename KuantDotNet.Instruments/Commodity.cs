using System.Collections.Generic;
using System.Linq;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments
{
    public class Commodity : IUnderlying
    {
        public string Name { get; set; }
        
        public double UnitPrice { get; set; }
        
        public string Unit { get; set; }
        public int Grade { get; set; }

        public bool IsFinancialAsset { get { return false; } }

        public Commodity(string name, int grade)
        {
            Name = name;
            Grade = grade;
            InitUnitPrice();
        }

        private void InitUnitPrice()
        {
            // according to specific commodity
            UnitPrice = Grade * 10; 
        }

        public double SpotPriceAsUnderlying(KDateTime index)
        {
            return UnitPrice; //simple simul
        }
    }
}
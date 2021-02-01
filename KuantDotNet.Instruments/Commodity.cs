using System.Collections.Generic;
using System.Linq;

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
        
        public List<double> SpotPricesAsUnderlying(int start, int end)
        {
            return Enumerable.Repeat(UnitPrice, end - start).ToList(); //simple simul
        }

        public List<double> SpotPricesAsUnderlying(int end)
        {
            return Enumerable.Repeat(UnitPrice, end).ToList();//simple simul
        }

        public double SpotPriceAsUnderlying(int index)
        {
            return UnitPrice; //simple simul
        }
    }
}
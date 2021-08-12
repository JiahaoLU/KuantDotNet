using System;
using Kuant.Common;
using Kuant.Products;
using Kuant.Utils;

namespace Kuant.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new ConstantNotionalSchedule();
            var swaption = new Swaption{
                Notional = n,
                StartDate = new KDateTime(2000,1,1),
                EndDate = new KDateTime(2020, 1, 1),
                Ccy = Common.Ccy.EUR,
                PoR = PayRecieve.P
            };
            System.Console.WriteLine(swaption);

            System.Console.ReadLine();
        }
    }
}

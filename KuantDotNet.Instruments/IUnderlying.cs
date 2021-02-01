using System.Collections.Generic;

namespace KuantDotNet.Instruments
{
    public interface IUnderlying
    {
        bool IsFinancialAsset { get; }
        List<double> SpotPricesAsUnderlying(int start, int end); // start included, end excluded
        List<double> SpotPricesAsUnderlying(int end); // start=0, end excluded
        double SpotPriceAsUnderlying(int index);
    }
}
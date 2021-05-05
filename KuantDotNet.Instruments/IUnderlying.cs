using System.Collections.Generic;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments
{
    public interface IUnderlying
    {
        bool IsFinancialAsset { get; }
        double SpotPriceAsUnderlying(KDateTime asof);
    }
}
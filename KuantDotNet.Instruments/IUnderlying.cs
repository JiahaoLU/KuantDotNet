namespace KuantDotNet.Instruments
{
    public interface IUnderlying
    {
        bool IsFinancialAsset { get; }
        double GetSpotPriceAsUnderlying();
    }
}
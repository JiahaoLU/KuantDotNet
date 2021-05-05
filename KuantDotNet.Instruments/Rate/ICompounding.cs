using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.Rate
{
    public interface ICompounding
    {
        double DiscountValue(double amount, KDateTime asof, KDateTime date);
        double ReturnValue(double amount, KDateTime asof, KDateTime date);
    }
}
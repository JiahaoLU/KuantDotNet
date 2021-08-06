using Kuant.Utils;

namespace Kuant.Common
{
    public interface ICompounding
    {
        double DiscountValue(KDateTime asof, KDateTime date);
        double ReturnValue(KDateTime asof, KDateTime date);
    }
}
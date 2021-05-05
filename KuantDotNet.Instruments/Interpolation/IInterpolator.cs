using System;
using System.Collections.Generic;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.Interpolation
{
    public interface IInterpolator<T>
    {
        T Interpolate(List<T> list, List<KDateTime> labels, KDateTime index);
    }

}
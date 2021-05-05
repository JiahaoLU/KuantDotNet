using System;
using System.Collections.Generic;
using System.Linq;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.Interpolation
{
    public class LinearInterpol<T> : IInterpolator<T>
    {
        public T Interpolate(List<T> list, List<KDateTime> labels, KDateTime index)
        {
            if(list.Count != labels.Count)
                throw new Exception("labels and values number not consistent.");
            
            var len = list.Count;
            var lastIdx = labels.LastOrDefault(s => s <= index);
            var nextIdx = labels.FirstOrDefault(s => s > index);
            double interpol;

            if (nextIdx == null)
            {
                if (len < 2) throw new Exception("list contains less than 2 elements, cannot do interpolation");

                //extrapolation
                interpol = (Convert.ToDouble(list[len - 1]) - Convert.ToDouble(list[len - 2]))
                            * (index - labels[len - 1]) / (labels[len - 1] - labels[len - 2])
                             + Convert.ToDouble(list[len - 1]);
                return (T)Convert.ChangeType(interpol, typeof(T));
            }
            if (lastIdx == null)
            {
                if (len < 2) throw new Exception("list contains less than 2 elements, cannot do interpolation");
                //extrapolation
                interpol = (Convert.ToDouble(list[1]) - Convert.ToDouble(list[0]))
                            * (index - labels[1]) / (labels[1] - labels[0])
                             + Convert.ToDouble(list[1]);
                return (T)Convert.ChangeType(interpol, typeof(T));
            }
            if (lastIdx == index || nextIdx == index)
                return list[labels.IndexOf(index)];

            interpol = (Convert.ToDouble(list[labels.IndexOf(nextIdx)]) - Convert.ToDouble(list[labels.IndexOf(lastIdx)]))
                        * (index - nextIdx) / (nextIdx - lastIdx)
                         + Convert.ToDouble(list[labels.IndexOf(nextIdx)]);
            return (T)Convert.ChangeType(interpol, typeof(T));
        }
    }
}
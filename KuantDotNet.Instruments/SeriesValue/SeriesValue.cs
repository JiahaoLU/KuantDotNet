using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using KuantDotNet.Instruments.Interpolation;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.SeriesValue
{
    public class SeriesValue<T> : ISeriesValue<KDateTime, T>
    {
        public List<KDateTime> Keys {get; set;}
        public List<T> Values { get; set; }
        
        public SeriesValue(IEnumerable<KDateTime> keys, IEnumerable<T> value)
        {
            Keys = keys.ToList();
            Values = value.ToList();
        }
        public IEnumerable<KDateTime> GetLabels()
        {
            return Keys;
        }

        public T GetValue(KDateTime label)
        {
            if (Keys.Contains(label))
                return Values[Keys.IndexOf(label)];

            return Interpolator<T>.LinearHandler
                    .Interpolate(Values, Keys, label);
        }

        public IEnumerable<T> GetValues()
        {
            return Values;
        }
    }
}
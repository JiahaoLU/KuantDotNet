using System.Collections.Generic;
using System.Linq;
using Kuant.Math;
using Kuant.Utils;

namespace Kuant.Common
{
    public class SeriesValue<T> : ISeriesValue<KDateTime, T>
    {
        public List<KDateTime> Keys {get; set;}
        public List<T> Values { get; set; }
        public InterpolType InterpolType { get; set; }
        
        
        public SeriesValue(IEnumerable<KDateTime> keys, IEnumerable<T> value, InterpolType interpolType)
        {
            Keys = keys.ToList();
            Values = value.ToList();
            InterpolType = interpolType;
        }
        public IEnumerable<KDateTime> GetLabels()
        {
            return Keys;
        }

        public T GetValue(KDateTime label)
        {
            if (Keys.Contains(label))
            {
                return Values[Keys.IndexOf(label)];
            }

            return Interpolator<KDateTime, T>
                    .Interpolate( Keys, Values, label, InterpolType);
        }

        public IEnumerable<T> GetValues()
        {
            return Values;
        }
    }
}
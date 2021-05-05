using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using KuantDotNet.Instruments.Interpolation;
using KuantDotNet.KuantDateTime;

namespace KuantDotNet.Instruments.SeriesValue
{
    public class ConstantValue<T> : ISeriesValue<KDateTime, T>
    {
        public List<KDateTime> Keys {get; set;}
        public T Constant { get; set; }

        private List<T> _values;
        public List<T> Values {
            get{
                if (_values == null)
                    _values = Enumerable.Repeat(Constant, Keys.Count).ToList();
                return _values;
            }
        }

        public ConstantValue(IEnumerable<KDateTime> keys, T value)
        {
            Keys = keys.ToList();
            Constant = value;
        }
        public ConstantValue(T value)
        {
            Constant = value;
        }
        public IEnumerable<KDateTime> GetLabels()
        {
            return Keys;
        }

        public T GetValue(KDateTime label)
        {
            return Constant;
        }

        public IEnumerable<T> GetValues()
        {
            return Values;
        }
    }
}
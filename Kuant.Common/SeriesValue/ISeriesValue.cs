using System;
using System.Collections.Generic;

namespace Kuant.Common
{
    public interface ISeriesValue<S, T> where S : IComparable<S>
    {
        public List<S> Keys {get;}
        public List<T> Values { get;}
         T GetValue(S label);
         IEnumerable<T> GetValues();
         IEnumerable<S> GetLabels();
    }
}